namespace EthioNutrition.Data
{
    public interface IVersionedModelObject
    {
        byte[] Version { get; set; }
    }
}
