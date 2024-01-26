using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Math;

namespace 
{
    public static class Tolerances
    {
        /// <summary>
        /// Upper limit calculation
        /// </summary>
        /// <param name="nominalSize">nominalSize from drawing</param>
        /// <param name="upperDeviation">upperDeviation from size tolerance</param>
        /// <returns>UpperLimit</returns>
        public static double UpperLimit(double  nominalSize, double upperDeviation){
            return nominalSize + upperDeviation;
        }
        /// <summary>
        /// Lower limit calculation
        /// </summary>
        /// <param name="nominalSize">Nominal lSize from drawing</param>
        /// <param name="upperDeviation">Upper Deviation from size tolerance</param>
        /// <param name="lowerDeviation">Lower Deviation from size tolerance</param>
        /// <returns>Lower limit</returns>
        public static double LowerLimit(double  nominalSize, double upperDeviation, double lowerDeviation){
            return UpperLimit(nominalSize,upperDeviation) - ToleranceCalulatoin(upperDeviation, lowerDeviation); 
        }
        /// <summary>
        ///  Middle size calculation
        /// </summary>
        /// <param name="nominalSize">Nominal lSize from drawing</param>
        /// <param name="upperDeviation">Upper Deviation from size tolerance</param>
        /// <param name="lowerDeviation">Lower Deviation from size tolerance</param>
        /// <returns>Middle size</returns>

        public static double Middle(double  nominalSize, double upperDeviation, double lowerDeviation){
            
            return UpperLimit(nominalSize,upperDeviation) - ToleranceCalulatoin(upperDeviation, lowerDeviation)*0.5;
        }

        public static double ToleranceCalulatoin(double upperDeviation, double lowerDeviation){
            return upperDeviation + Math.Abs(lowerDeviation);
        }

        /// <summary>
        /// Recalculates nominal size to ne size with
        /// symmtrycal Upper Deviation and Lower Deviation
        /// but saves upper and lowe limits
        /// </summary>
        /// <param name="nominalSize">Nominal lSize from drawing</param>
        /// <param name="upperDeviation">Upper Deviation from size tolerance</param>
        /// <param name="lowerDeviation">Lower Deviation from size tolerance</param>
        /// <returns></returns>
        public static (double newNominalSize, double deviation) NominalToSymmetric(double  nominalSize, double upperDeviation, double lowerDeviation){
            return (Middle(nominalSize, upperDeviation, lowerDeviation), ToleranceCalulatoin(upperDeviation, lowerDeviation)*0.5);
        }
    }
}