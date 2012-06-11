using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SinZationalSockets {
    public class SinZSockets {
        private NetworkStream stream;

        public SinZSockets(NetworkStream stream) {
            this.stream = stream;
        }
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Strings               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public String readString() {
            short len = readShort();
            byte[] buffer = new byte[len * 2];
            stream.Read(buffer, 0, buffer.Length);
            String result = Encoding.BigEndianUnicode.GetString(buffer);

            return result;
        }

        public void writeString(String msg) {
            short len = IPAddress.HostToNetworkOrder((short)msg.Length);
            byte[] a = BitConverter.GetBytes(len);
            byte[] b = Encoding.BigEndianUnicode.GetBytes(msg);
            byte[] c = a.Concat(b).ToArray();
            stream.Write(c, 0, c.Length);
        }


        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Shorts               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        public short readShort() {
            byte a = (byte)stream.ReadByte();
            byte b = (byte)stream.ReadByte();

            short result = BitConverter.ToInt16(new byte[2] { a, b }, 0);
            return result;
        }

        public void writeShort(short message) {
            byte[] bytes = BitConverter.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }

        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Ints               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        public int readInt() {
            byte a = (byte)stream.ReadByte();
            byte b = (byte)stream.ReadByte();
            byte c = (byte)stream.ReadByte();
            byte d = (byte)stream.ReadByte();

            int result = BitConverter.ToInt32(new byte[4] { a, b, c, d }, 0);
            return result;
        }

        public void writeInt(int message) {
            byte[] bytes = BitConverter.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
            foreach(byte b in bytes) {
                Console.Out.WriteLine(b);
            }
        }

        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Longs               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        public long readLong() {
            byte a = (byte)stream.ReadByte();
            byte b = (byte)stream.ReadByte();
            byte c = (byte)stream.ReadByte();
            byte d = (byte)stream.ReadByte();
            byte e = (byte)stream.ReadByte();
            byte f = (byte)stream.ReadByte();
            byte g = (byte)stream.ReadByte();
            byte h = (byte)stream.ReadByte();

            long result = BitConverter.ToInt64(new byte[8] { a, b, c, d, e, f, g, h}, 0);
            return result;
        }

        public void writeLong(long message) {
            byte[] bytes = BitConverter.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }

        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Doubles               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        public double readDouble() {
            byte a = (byte)stream.ReadByte();
            byte b = (byte)stream.ReadByte();
            byte c = (byte)stream.ReadByte();
            byte d = (byte)stream.ReadByte();
            byte e = (byte)stream.ReadByte();
            byte f = (byte)stream.ReadByte();
            byte g = (byte)stream.ReadByte();
            byte h = (byte)stream.ReadByte();

            double result = BitConverter.ToDouble(new byte[8] { a, b, c, d, e, f, g, h }, 0);
            return result;
        }

        public void writeDouble(double message) {
            byte[] bytes = BitConverter.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }


        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Floats               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        public float readFloat() {
            byte a = (byte)stream.ReadByte();
            byte b = (byte)stream.ReadByte();
            byte c = (byte)stream.ReadByte();
            byte d = (byte)stream.ReadByte();

            float result = BitConverter.ToSingle(new byte[4] { a, b, c, d }, 0);
            return result;
        }

        public void writeFloat(float message) {
            byte[] bytes = BitConverter.GetBytes(message);
            stream.Write(bytes, 0, bytes.Length);
        }

        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Bytes               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        public sbyte readByte() {
            sbyte a = (sbyte)stream.ReadByte();
            return a;
        }

        public void writeByte(sbyte message) {
            stream.WriteByte((byte) message);
        }

        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
        /*           Bools               */
        /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/

        public bool readBool() {
            byte a = (byte)stream.ReadByte();
            bool result = Convert.ToBoolean(a);
            return result;
        }
        public void writeBool(bool message) {
            byte x = Convert.ToByte(message);
            stream.WriteByte(x);
        }
    }
}
