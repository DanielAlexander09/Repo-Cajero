using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewsModels;

namespace Application.ViewModels
{
	public class CajeroListViewModels
	{
		public List<CajeroViewModels> Modo1 { get; set; } = new();
		public List<CajeroViewModels> Modo2 { get; set; } = new();
		public List<CajeroViewModels> ModoEficiente { get; set; } = new();
	}
}
