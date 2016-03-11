
public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public int Year { get; set; }
    public int TransmissionType { get; set; }
    public string ManufacturerName { get; set; }
    public string Model { get; set; }
    public float Price { get; set; }
    public Dealer Dealer { get; set; }
}

public class Dealer
{
    public string Name { get; set; }
    public string City { get; set; }
}
