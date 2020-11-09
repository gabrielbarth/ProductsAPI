using System;
using System.Collections.Generic;
using System.Text;

namespace Estudos.Aplicacao.Interfaces
{
    public interface IAdapter<TOrigem, TDestido>
    {
        TDestido MapearEntidadeParaDTO(TOrigem origem);
    }
}
