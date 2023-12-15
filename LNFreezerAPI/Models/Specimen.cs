namespace LNFreezerApi.Models
{
  public class Specimen
  {
    public int SpecimenId { get; set; }
    public int SpecimenNum { get; set; }
    public string Cohort { get; set; }
    public int NHPNum { get; set; }
    public int Date { get; set; }
    public string Tissue { get; set; }
    public string Quantity { get; set; }
    public int BoxId { get; set; }
  }
}