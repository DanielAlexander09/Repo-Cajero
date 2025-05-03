
using Application.Enums;
using Application.Repositories;
using Application.ViewModels;
using Application.ViewsModels;

namespace Application.Services
{
	public class CajeroServices
	{

		public string Add(CreateCajeroViewModels vm)
		{
			switch (vm.Modo_Dispensador)
			{
				case (int)CajeroType.Modo1:
					// Validación corregida
					if (vm.monto < 0 || vm.monto % 100 != 0)
					{
						return "Este cajero no dispensa billetes que no sean múltiplos de 100.";
					}

					// Agregar monto a la lista
					CajeroRepositories.Instance.Cajero.Modo1.Add(new CajeroViewModels
					{
						monto = vm.monto
					});

					// Obtener el último elemento
					var ultimoCajero = CajeroRepositories.Instance.Cajero.Modo1.LastOrDefault();
					if (ultimoCajero != null)
					{
						var billetes1000 = (int) ultimoCajero.monto / 1000;
						var restante = ultimoCajero.monto % 1000;

						var billetes200 = restante / 200;

						if (restante % 200 != 0)
						{
							return "Error: El monto ingresado no puede ser dispensado con los billetes disponibles.";
						}

						return $"Se dispensaron {billetes1000} billetes de 1000 y {billetes200} billetes de 200.";
					}

					return "Error: No se pudo procesar el monto.";


				    case (int)CajeroType.Modo2:

                    // Validación corregida
                    if (vm.monto < 0)
                    {
                        return "Este cajero no dispensa billetes que no sean múltiplos de 100.";
                    }

                    // Agregar monto a la lista
                    CajeroRepositories.Instance.Cajero.Modo1.Add(new CajeroViewModels
                    {
                        monto = vm.monto
                    });

                    // Obtener el último elemento
                    var ultimoCajero1 = CajeroRepositories.Instance.Cajero.Modo1.LastOrDefault();
                    if (ultimoCajero1 != null)
                    {
                        var billetes500 = (int)ultimoCajero1.monto / 500;
                        var restante = ultimoCajero1.monto % 500;

                        var billetes100 = restante / 100;

                        

                        return $"Se dispensaron {billetes500} billetes de 500 y {billetes100} billetes de 100.";
                    }

                    return "Error: No se pudo procesar el monto.";

                    case (int)CajeroType.ModoEficiente:
                        // Validar que el monto sea mayor a 0 y múltiplo de 100
                        if (vm.monto <= 0 || vm.monto % 100 != 0)
                        {
                        return "Este cajero no dispensa billetes que no sean múltiplos de 100.";
                        }

                         // Agregar monto a la lista del modo eficiente (asegúrate de tener la colección correcta)
                            CajeroRepositories.Instance.Cajero.ModoEficiente.Add(new CajeroViewModels
                            {
                             monto = vm.monto
                            });

                        // Obtener el último elemento agregado en modo eficiente
                        var ultimoCajeroEficiente = CajeroRepositories.Instance.Cajero.ModoEficiente.LastOrDefault();
                         if (ultimoCajeroEficiente != null)
                           {
                             int montoActual = (int)ultimoCajeroEficiente.monto;

                            // Calcular la cantidad de billetes para cada denominación
                             int billetes1000 = montoActual / 1000;
                             int restante = montoActual % 1000;

                              int billetes500 = restante / 500;
                              restante %= 500;

                              int billetes200 = restante / 200;
                              restante %= 200;

                              int billetes100 = restante / 100;
                              restante %= 100;

                            // Si al final sobra algún monto que no se puede dispensar, se retorna un error
                             if (restante != 0)
                             {
                              return "Error: El monto ingresado no puede ser dispensado con los billetes disponibles.";
                             }

                             return $"Se dispensaron {billetes1000} billetes de 1000, {billetes500} billetes de 500, {billetes200} billetes de 200 y {billetes100} billetes de 100.";
                             }

                             return "Error: No se pudo procesar el monto.";


                            default:
					        return "Error: Modo dispensador no válido.";
			                }
		}

		public CajeroListViewModels GetAll()
		{
			return CajeroRepositories.Instance.Cajero;
		}

	}
}
