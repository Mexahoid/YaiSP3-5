using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    /// <summary>
    /// Класс очереди клиентов.
    /// </summary>
    public class QueueClass
    {
        /// <summary>
        /// Класс узла очереди.
        /// </summary>
        class QueueNodeClass
        {
            #region Поля

            /// <summary>
            /// Клиент узла.
            /// </summary>
            private TemplateClient nodeClient;

            /// <summary>
            /// Следующий узел.
            /// </summary>
            private QueueNodeClass nodeNext;

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
            public QueueNodeClass NodeNext
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
            public QueueNodeClass(TemplateClient Data, QueueNodeClass Next)
            {
                NodeClient = Data;
                NodeNext = Next;
            }
        }

        #region Поля

        /// <summary>
        /// Голова очереди
        /// </summary>
        private QueueNodeClass queueHead;
        /// <summary>
        /// Хвост очереди
        /// </summary>
        private QueueNodeClass queueTail;

        #endregion

        #region Методы

        /// <summary>
        /// Конструктор очереди.
        /// </summary>
        public QueueClass()
        {
            queueHead = queueTail = null;
        }

        /// <summary>
        /// Добавляет клиента в хвост очереди.
        /// </summary>
        /// <param name="Data">Добавляемый клиент.</param>
        public void QueueAdd(TemplateClient Data)
        {
            QueueNodeClass NewNode = new QueueNodeClass(Data, null);
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
            QueueNodeClass Out = queueHead;
            queueHead = queueHead.NodeNext;
            return Out.NodeClient;
        }

        /// <summary>
        /// Есть ли в очереди высокоприоритетный клиент.
        /// </summary>
        /// <returns>Возвращает логическое значение.</returns>
        private bool QueueHasHighPriority()
        {
            QueueNodeClass Q = queueHead;
            if (Q.NodeClient.GetType() == typeof(ClientGovernment))
                return true;
            else
            {
                while (Q.NodeNext != null)
                {
                    Q = Q.NodeNext;
                    if (Q.NodeClient.GetType() == typeof(ClientGovernment))
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
            QueueNodeClass Q = queueHead;
            if (Q.NodeClient.GetType() == typeof(ClientGovernment))
            {
                TemplateClient C = Q.NodeClient;
                queueHead = Q.NodeNext;
                return C;
            }
            else
                while (Q.NodeNext != null && 
                    Q.NodeNext.NodeClient.GetType() != typeof(ClientGovernment))
                    Q = Q.NodeNext;
            QueueNodeClass P = Q.NodeNext;
            Q.NodeNext = P.NodeNext;
            return P.NodeClient;
        }


        public TemplateClient QueueTakeClient()
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
                QueueNodeClass Q = queueHead;
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
                QueueNodeClass Node = queueHead;
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
