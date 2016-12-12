using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgencySimulator.Interfaces;
using AgencySimulator.Types;

namespace AgencySimulator.Queue
{
    public class Queue : IQueue
    {
        /// <summary>
        /// Класс узла очереди.
        /// </summary>
        class QueueNode
        {
            #region Поля

            /// <summary>
            /// Клиент узла.
            /// </summary>
            private TemplateClient nodeClient;

            /// <summary>
            /// Следующий узел.
            /// </summary>
            private QueueNode nodeNext;

            /// <summary>
            /// Клиент узла.
            /// </summary>
            public TemplateClient NodeClient
            {
                get
                {
                    return nodeClient;
                }

                set
                {
                    nodeClient = value;
                }
            }

            /// <summary>
            /// Следующий узел.
            /// </summary>
            public QueueNode NodeNext
            {
                get
                {
                    return nodeNext;
                }

                set
                {
                    nodeNext = value;
                }
            }

            #endregion

            /// <summary>
            /// Конструктор узла очереди.
            /// </summary>
            /// <param name="Data">Клиент в узле.</param>
            /// <param name="Next">Указатель на следующего клиента.</param>
            public QueueNode(TemplateClient Data, QueueNode Next)
            {
                NodeClient = Data;
                NodeNext = Next;
            }

            /// <summary>
            /// Конструктор узла очереди.
            /// </summary>
            /// <param name="Data">Клиент в узле.</param>
            /// <param name="Next">Указатель на следующего клиента.</param>
            public QueueNode(IClient Data, QueueNode Next)
            {
                NodeClient = (TemplateClient)Data;
                NodeNext = Next;
            }
        }

        #region Поля

        /// <summary>
        /// Голова очереди
        /// </summary>
        private QueueNode queueHead;

        /// <summary>
        /// Хвост очереди
        /// </summary>
        private QueueNode queueTail;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор очереди.
        /// </summary>
        public Queue()
        {
            queueHead = queueTail = null;
        }

        /// <summary>
        /// Добавляет клиента в хвост очереди.
        /// </summary>
        /// <param name="Data">Добавляемый клиент.</param>
        public void QueueAdd(IClient Data)
        {
            QueueNode NewNode = new QueueNode(Data, null);
            if (QueueIsNull())
                queueHead = queueTail = NewNode;
            else
            {
                queueTail.NodeNext = NewNode;
                queueTail = NewNode;
            }
        }

        /// <summary>
        /// Пустая ли очередь.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        public bool QueueIsNull()
        {
            return queueHead == null;
        }

        /// <summary>
        /// Выдача обычного клиента из очереди.
        /// </summary>
        /// <returns>Возвращает экземпляр клиента.</returns>
        private TemplateClient QueuePushNormal()
        {
            QueueNode Out = queueHead;
            queueHead = queueHead.NodeNext;
            return Out.NodeClient;
        }

        /// <summary>
        /// Есть ли в очереди высокоприоритетный клиент.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        private bool QueueHasHighPriority()
        {
            QueueNode Q = queueHead;
            if (Q.NodeClient.GetType() == ClientLevel.Government)
                return true;
            else
            {
                while (Q.NodeNext != null)
                {
                    Q = Q.NodeNext;
                    if (Q.NodeClient.GetType() == ClientLevel.Government)
                        return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Выдача высокоприоритетного клиента из очереди.
        /// </summary>
        /// <returns>Возвращает экземпляр клиента.</returns>
        private TemplateClient QueuePushHighPriority()
        {
            QueueNode Q = queueHead;
            if (Q.NodeClient.GetType() == ClientLevel.Government)
            {
                TemplateClient C = Q.NodeClient;
                queueHead = Q.NodeNext;
                return C;
            }
            else
                while (Q.NodeNext != null &&
                    Q.NodeNext.NodeClient.GetType() != ClientLevel.Government)
                    Q = Q.NodeNext;
            QueueNode P = Q.NodeNext;
            Q.NodeNext = P.NodeNext;
            return P.NodeClient;
        }

        /// <summary>
        /// Выдача клиента из очереди.
        /// </summary>
        /// <returns>Возвращает экземпляр IClient.</returns>
        public IClient QueueTakeClient()
        {
            if (QueueHasHighPriority())
                return QueuePushHighPriority();
            else
                return QueuePushNormal();
        }

        /// <summary>
        /// Выдача информации о клиентах одной строкой.
        /// </summary>
        /// <returns>Возвращает строку.</returns>
        public override string ToString()
        {
            string Out = "";
            if (!QueueIsNull())
            {
                QueueNode Q = queueHead;
                if (Q.NodeNext == null)
                    return Q.NodeClient.GetTextData();
                else
                    while (Q != null)
                    {
                        Out += Q.NodeClient.GetTextData() + "\n=================" + Environment.NewLine;
                        Q = Q.NodeNext;
                    }
            }
            return Out;
        }

        /// <summary>
        /// Возвращает количество клиентов в очереди.
        /// </summary>
        /// <returns>Возвращает целочисленное значений.</returns>
        public int GetQueueCount()
        {
            if (!QueueIsNull())
            {
                QueueNode Node = queueHead;
                int Count = 1;
                while (Node.NodeNext != null)
                {
                    Node = Node.NodeNext;
                    Count++;
                }
                return Count;
            }
            return 0;
        }

        #endregion
    }
}
