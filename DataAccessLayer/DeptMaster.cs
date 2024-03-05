using System.Collections.Generic;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer
{
    public class DeptMaster
    {
        [Key]
        public int DeptCode { get; set; }
        public string DeptName { get; set; }

        [JsonIgnore]
        public virtual ICollection<EmpProfile> EmpProfiles { get; set; }
    }
}