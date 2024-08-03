public interface IConnectable
{
    int ElementId { get; }
    bool IsPowerSource { get; }
    bool HasPower { get; set; }
    void CheckConnection();
}
