using System;
using System.IO;

namespace Spring.Util
{
	/// <summary>
	/// Utility methods for IO handling
	/// </summary>
    internal sealed class IOUtils
    {
        private IOUtils()
        {
            throw new InvalidOperationException("instantiation not supported");
        }
		
        /// <summary>
        /// Copies one stream into another. 
        /// (Don't forget to call <see cref="Stream.Flush"/> on the destination stream!)
        /// </summary>
        /// <remarks>
        /// Does not close the input stream!
        /// </remarks>
        public static void CopyStream( Stream src, Stream dest )
        {
            int bufferSize = 2048;
            byte[] buffer = new byte[bufferSize];

            int bytesRead = src.Read(buffer, 0, bufferSize);
            while( bytesRead == bufferSize )
            {
                dest.Write( buffer, 0, bytesRead );
                bytesRead = src.Read( buffer, 0, bufferSize );
            }
            if (bytesRead > 0)
            {
                dest.Write( buffer, 0, bytesRead );
            }    
        }
        
        /// <summary>
        /// Reads a stream into a byte array. 
        /// </summary>
        /// <remarks>
        /// Does not close the input stream!
        /// </remarks>
        public static byte[] ToByteArray( Stream src )
        {
            MemoryStream stm = new MemoryStream();
            CopyStream( src, stm );
            stm.Flush();
            return stm.ToArray();
        }	    
				
    }
}
