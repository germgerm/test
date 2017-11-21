using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DbApp.Data
{
	public abstract class Base {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }		
	}

	public class Thing1 : Base
	{
		public Thing1()
		{
		}

		[MaxLength(100)]
		public string Name { get; set; }
		[MaxLength(200)]
		public string Description { get; set; }


		public override string ToString()
		{
			return JsonConvert.SerializeObject( this, Formatting.Indented );
		}

	}
}

