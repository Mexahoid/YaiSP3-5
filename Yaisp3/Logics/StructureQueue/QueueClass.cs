using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yaisp3
{
    class QueueClass
    {
        class QueueNodeClass
        {
            private Client nodeClient;
            private QueueNodeClass nodeNext;

            public QueueNodeClass(Client Data, QueueNodeClass Next)
            {
                NodeClient = Data;
                NodeNext = Next;
            }

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

            public Client NodeClient
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
        }

        private QueueNodeClass queueHead;
        private QueueNodeClass queueTail;

        public QueueClass()
        {
            queueHead = queueTail = null;
        }

        public void QueueAdd(Client Data)
        {
            QueueNodeClass NewNode = new QueueNodeClass(Data, null);
            if (QueueIsNull())
                queueHead = queueTail = NewNode;
            else
                queueTail.NodeNext = NewNode;
        }

        public bool QueueIsNull()
        {
            return queueHead == null;
        }

        public Client QueuePushNormal()
        {
            QueueNodeClass Out = queueHead;
            queueHead = queueHead.NodeNext;
            return Out.NodeClient;
        }

        public bool QueueHasHighPriority()
        {
            QueueNodeClass Q = queueHead;
            if (Q.NodeClient.IsHighPriority())
                return true;
            else
            {
                while (Q.NodeNext != null)
                {
                    Q = Q.NodeNext;
                    if (Q.NodeClient.IsHighPriority())
                        return true;
                }
                return false;
            }
        }

        public Client QueuePushHighPriority()
        {
            QueueNodeClass Q = queueHead;
            if (Q.NodeClient.IsHighPriority())
            {
                Client C = Q.NodeClient;
                queueHead = Q.NodeNext;
                return C;
            }
            else
                while (Q.NodeNext != null && !Q.NodeNext.NodeClient.IsHighPriority())
                    Q = Q.NodeNext;
            QueueNodeClass P = Q.NodeNext;
            Q.NodeNext = P.NodeNext;
            return P.NodeClient;
        }
        public string GetQueueOrders()
        {
            string Out = "";
            if (!QueueIsNull())
            {
                QueueNodeClass Q = queueHead;
                if (Q.NodeNext == null)
                    return Q.NodeClient.GetTextData();
                else
                    while (Q.NodeNext != null)
                    {
                        Q = Q.NodeNext;
                        Out += Q.NodeClient.GetTextData() + '\n';
                    }
            }
            return Out;
        }
    }
}
