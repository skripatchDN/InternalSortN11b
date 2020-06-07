using System.Collections.Generic;

namespace InternalSort_n11b_
{
    public class Sorter
    {
        // список действий при сортировке
        public List<ActionHandle> ActionList;
        public int Compares { get; set; }
        public int Assignments { get; set; }
        public int LinkAssignments { get; set; }
        

        public Sorter()
        {
            ActionList = new List<ActionHandle>();
            Compares = 0;
            Assignments = 0;
            LinkAssignments = 0;
        }

        /// <summary>
        /// Основная функция сортировки
        /// </summary>
        /// <param name="array">Сортируемый массив</param>
        public void DoubleSidedInsertSort(ref int[] array)
        {
            ActionList.Clear();
            Compares = 0;
            Assignments = 0;
            LinkAssignments = 0;
            int support = array[0];
            // индекс самого левого элемента
            int leftIndex = array.Length;
            // индекс центрального элемента
            int centerIndex = array.Length;

            DoublyLinkedList list = new DoublyLinkedList();
            Queue<ActionHandle> tmpActions = new Queue<ActionHandle>();
            list.OrderAddFromLeft(array[0], tmpActions, 0);
            tmpActions.Clear();
            ActionList.Add(new ActionHandle(centerIndex, centerIndex, Act.InsertFirstElem));
            for (int i = 1; i < array.Length; i++)
            {
                ActionList.Add(new ActionHandle(i, centerIndex, Act.Compare));
                if (array[i] < support)
                {
                    list.OrderAddFromLeft(array[i], tmpActions, i);
                    foreach (var act in tmpActions)
                    {
                        if (act.Act == Act.InsertBefore)
                        {
                            leftIndex--;
                            LinkAssignments++;
                            ActionList.Add(new ActionHandle(i, leftIndex, Act.InsertLeftIn));
                        }
                        else if (act.Act == Act.InsertAfter)
                        {
                            LinkAssignments++;
                            ActionList.Add(new ActionHandle(i, leftIndex + list.Count - 1, Act.InsertLeftIn));
                        }
                        else if (act.Act == Act.InsertBetween)
                        {
                            leftIndex--;
                            LinkAssignments += 2;
                            ActionList.Add(new ActionHandle(i, leftIndex + act.First + 1, Act.InsertLeftIn));
                        }
                        else if (act.Act == Act.Compare)
                        {
                            ActionList.Add(new ActionHandle(i, leftIndex + act.Second, Act.Compare));
                            Compares++;
                        }
                    }
                    tmpActions.Clear();
                }
                else
                {
                    list.OrderAddFromRight(array[i], tmpActions, i);
                    foreach (var act in tmpActions)
                    {
                        if (act.Act == Act.InsertBefore)
                        {
                            leftIndex--;
                            LinkAssignments++;
                            ActionList.Add(new ActionHandle(i, leftIndex, Act.InsertRightIn));
                        }
                        else if (act.Act == Act.InsertAfter)
                        {
                            LinkAssignments++;
                            ActionList.Add(new ActionHandle(i, leftIndex + list.Count-1, Act.InsertRightIn));
                        }
                        else if (act.Act == Act.InsertBetween)
                        {
                            LinkAssignments += 2;
                            ActionList.Add(new ActionHandle(i, leftIndex + act.First, Act.InsertRightIn));
                        }
                        else if (act.Act == Act.Compare)
                        {
                            ActionList.Add(new ActionHandle(i, leftIndex + act.Second, Act.Compare));
                            Compares++;
                        }
                    }
                    tmpActions.Clear();
                }
            }

            int[] listRes = list.ToArray();
            for (int i = 0; i < list.Count; i++)
            {
                ActionList.Add(new ActionHandle(i, i, Act.MoveBack));
                array[i] = listRes[i];
            }

        }

    }
}
