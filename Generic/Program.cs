namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory<Potion> potionInventory = new(10);

            potionInventory.Add(new Potion("체력 포션"));

            potionInventory.PrintItenNames();
        }
    }
}

//추상클래스 Item 생성
public abstract class Item
{
    // 이름은 외부에서  부를 수는 있지만,  값을 변경할 수는 없다.
    // 상속받은 클래스에서 부모생성자를 호출하면서 이름을 설정.
    public string Name { get; private set; }

    public Item(string name)
    {
        Name = name;
    }
}

//추상클래스 아이템을 상속받은 구체적 클래스 Potion
public class Potion : Item
{
    //Potion클래스가 생성되면, 부모생성자 호출 하고 자신의 생성자 호출
    public Potion(String name) : base(name)
    {

    }
}

//ITem을 상속받은 클래스 형식만 받는 클래스 Inventory
public class Inventory<T> where T : Item
{
    // ITem 또는 ITem을 상속받은 클래스 형식의 배열
    private T[] _list;
    private int _index;

    //생성자를 통해 Item형식의 배열 초기화
    public Inventory(int size)
    {
        _list = new T[size];
    }

    //배열에 넣기
    public void Add(T item)
    {
        if(_index < _list.Length)
        {
            _list[_index] = item;
            _index++;
        }
    }
    //배열에서 빼기
    public void Remove()
    {
        if(_index > 0)
        {
            _index--;
            _list[_index] = null;
        }
    }
    //배열에 있는 아이템들 출력
    public void PrintItenNames()
    {
        Console.WriteLine("아이템 목록:");

        foreach ( T item in _list)
        {
            if(item != null)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

}