using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;
using Application.ViewsModels;

namespace Application.Repositories
{
	public class CajeroRepositories
	{
		private CajeroRepositories() { }

		public static CajeroRepositories Instance { get; } = new();

		public CajeroListViewModels Cajero { get; set; }= new ();
	}
}
