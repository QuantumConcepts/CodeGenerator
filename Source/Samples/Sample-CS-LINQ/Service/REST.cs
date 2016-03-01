using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Sample.Service.Utils;
using System.ServiceModel;

namespace QuantumConcepts.CodeGenerator.Sample.Service
{
    public partial class REST
    {
        private static IEnumerable<T> GetPage<T>(IEnumerable<T> items, string page)
        {
            return ServiceUtil.GetPage(items, ParseInt("page", page));
        }

        private static int ParseInt(string parameterName, string valueString)
        {
            int value;

            if (!int.TryParse(valueString, out value))
                throw new FaultException<ServiceFault>(new ServiceFault(), new InvalidParameterFaultReason(string.Format("Parameter \"{0}\" is invalid. An integer was expected.", parameterName)));

            return value;
        }

        private static DateTime ParseDateTime(string parameterName, string valueString)
        {
            DateTime value;

            if (!DateTime.TryParse(valueString, out value))
                throw new FaultException<ServiceFault>(new ServiceFault(), new InvalidParameterFaultReason(string.Format("Parameter \"{0}\" is invalid. A DateTime was expected.", parameterName)));

            return value;
        }

        private static T ParseEnumeration<T>(string parameterName, string valueString)
            where T : struct
        {
            T value;

            if (!Enum.TryParse<T>(valueString, out value))
                throw new FaultException<ServiceFault>(new ServiceFault(), new InvalidParameterFaultReason(string.Format("Parameter \"{0}\" is invalid. An enumeration of type {1} was expected.", parameterName, typeof(T).Name)));

            return value;
        }
    }
}
