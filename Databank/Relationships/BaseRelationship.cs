namespace DataBank
{
	public class BaseRelationship : IEntity {
        private int id1;
        private int id2;

        public int Id1 { get => id1; set => id1 = value; }
        public int Id2 { get => id2; set => id2 = value; }

        public BaseRelationship(int id1, int id2)
        {
            Id1 = id1;
            Id2 = id2;
        }

        public static BaseRelationship getFakeRel()
        {
            return new BaseRelationship(0, 0);
        }
    }
}