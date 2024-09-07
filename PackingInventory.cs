Pack pack = new Pack(4, 10, 10);
Console.WriteLine("Add item:--> Arrow / Bow / Rope / Water / Food / Sword");
Display(0);
InventoryItem[]? inventoryItems = new InventoryItem[pack.TotalItem];
int i = 0;
while (true)
{
    string Useritem = Console.ReadLine()!;
    InventoryItem? itemList = Useritem?.ToLower() switch
    {
        "arrow" => new Arrow(),
        "bow" => new Bow(),
        "rope" => new Rope(),
        "water" => new Water(),
        "food" => new Food(),
        "sword" => new Sword(),
        _ => null
    };
    if (itemList == null) { continue; }
    inventoryItems[i] = itemList!; // i+1..i+2...are all null 
    if (pack.Packing(inventoryItems) == false) break;
    i++;
    Display(i);
    Resetvalue();
}

void Display(float i)
{
    Console.WriteLine($"""
        Current Count: {i}/ Max Count: {pack.TotalItem} 
        Current Weight:{pack.CurrentArrayWeight}/ Max Weight: {pack.MaxWeight}
        Current Volume:{pack.CurrentArrayVolume}/ Max Volume: {pack.MaxVolume}
        """);
}
void Resetvalue() //PUT IN END 
{
    pack.CurrentArrayWeight = 0; //Reset so that value of previous array would be erazed 
    pack.CurrentArrayVolume = 0;
    pack.CurrentArrayCount = 0;
}

public class InventoryItem
{
    public float Weight { get; protected set; }
    public float Volume { get; protected set; }
    public InventoryItem(float weight, float volume)
    {
        Weight = weight;
        Volume = volume;
    }
}
class Pack
{
    public int TotalItem { get; set; } = 0;
    public float MaxWeight { get; set; }
    public float MaxVolume { get; set; }
    public float CurrentArrayVolume = 0;
    public float CurrentArrayWeight = 0;
    public float CurrentArrayCount = 0;
    public bool Packing(InventoryItem[] item)
    {//

        foreach (InventoryItem currentWeight in item)
        {
            if (currentWeight == null) continue;
            CurrentArrayWeight += currentWeight.Weight;
            CurrentArrayVolume += currentWeight.Volume;
            CurrentArrayCount++;
            if (CurrentArrayWeight > MaxWeight) { Console.WriteLine("Exceed Max Weight Limit"); return false; }
            if (CurrentArrayVolume > MaxVolume) { Console.WriteLine("Exceed Max Volume Limit"); return false; }
            if (CurrentArrayCount == TotalItem) { Console.WriteLine("Exceed Max Item Limit"); return false; } 
        }
        return true;
    }
    public Pack(int totalItem, float maxWeight, float maxVolume)
    {
        TotalItem = totalItem;
        MaxWeight = maxWeight;
        MaxVolume = maxVolume;
    }
}
public class Arrow : InventoryItem { public Arrow() : base(0.1f, 0.05f) { } }
public class Bow : InventoryItem { public Bow() : base(1, 4) { } }
public class Rope : InventoryItem { public Rope() : base(1, 1.5f) { } }
public class Water : InventoryItem { public Water() : base(2, 3) { } }
public class Food : InventoryItem { public Food() : base(1, 0.5f) { } }
public class Sword : InventoryItem { public Sword() : base(5, 3) { } }
public class Nothing : InventoryItem { public Nothing() : base(0, 0) { } }
