using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DientesLimpios.Aplicacion.Contratos.Notificaciones
{
    public interface IServicioNotificaciones
    {
        Task EnviarConfirmacionCita(ConfirmacionCitaDTO cita);
        Task EnviarRecordatorioCita(RecordatorioCitaDTO cita);
    }
}
