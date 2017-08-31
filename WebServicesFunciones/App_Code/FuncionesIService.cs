using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using  System.Data;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface FuncionesIService
{
    [OperationContract]
    string GenerarDocumentosRrhh(Funciones funciones);

}


[DataContract]

public class Funciones
{
    private string _usuario;
    private string _contrasena;
    private string _compania;
    private string _proceso;

    [DataMember]
    public string Usuario
    {
        get { return _usuario; }
        set { _usuario = value; }
    }

    [DataMember]
    public string Contrasena
    {
        get { return _contrasena; }
        set { _contrasena = value; }
    }

    [DataMember]
    public string Compania
    {
        get { return _compania; }
        set { _compania = value; }
    }

    [DataMember]
    public string Proceso
    {
        get { return _proceso; }
        set { _proceso = value; }
    }
}
