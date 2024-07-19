namespace Padrrif.Entities
{
    public class DamageReport : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string>? StageSignaturePath { get; set; } 

        //CurrentStage begging with Zero to enhance the logic at UOW
        public int CurrentStage { get; set; } = 0;

       
 
    }
}
