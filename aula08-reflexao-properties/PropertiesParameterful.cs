using System;

public sealed class BitArray
{
    // Private array of bytes that hold the bits
    private Byte[] m_byteArray;
    private Int32 m_numBits;

    // Constructor that allocates the byte array and sets all bits to 0
    public BitArray(Int32 numBits)
    {
        // Validate arguments first.
        if (numBits <= 0)
            throw new ArgumentOutOfRangeException("numBits must be > 0");

        // Save the number of bits.
        m_numBits = numBits;

        // Allocate the bytes for the bit array.
        m_byteArray = new Byte[(m_numBits + 7) / 8];
    }


    // This is the indexer.
    public Boolean this[Int32 bitPos]
    {
        // This is the index property’s get accessor method.
        get
        {
            // Validate arguments first
            if ((bitPos < 0) || (bitPos >= m_numBits))
                throw new ArgumentOutOfRangeException("bitPos", "bitPos must be between 0 and " + m_numBits);

            // Return the state of the indexed bit.
            return ((m_byteArray[bitPos / 8] & (1 << (bitPos % 8))) != 0);
        }

        // This is the index property’s set accessor method.
        set
        {
            if ((bitPos < 0) || (bitPos >= m_numBits))
                throw new ArgumentOutOfRangeException("bitPos", "bitPos must be between 0 and " + m_numBits);

            if (value)
            {
                // Turn the indexed bit on.
                m_byteArray[bitPos / 8] = (Byte)
                   (m_byteArray[bitPos / 8] | (1 << (bitPos % 8)));
            }
            else
            {
                // Turn the indexed bit off.
                m_byteArray[bitPos / 8] = (Byte)
                   (m_byteArray[bitPos / 8] & ~(1 << (bitPos % 8)));
            }
        }
    }
}

public class Program
{
    public static void Main(String[] args)
    {
        // Allocate a BitArray that can hold 14 bits.
        BitArray ba = new BitArray(14);

        // Turn all the even-numbered bits on by calling the set accessor.
        for (Int32 x = 0; x < 14; x++)
        {
            ba[x] = (x % 2 == 0);
        }

        // Show the state of all the bits by calling the get accessor.
        for (Int32 x = 0; x < 14; x++)
        {
            Console.WriteLine("Bit " + x + " is " + (ba[x] ? "On" : "Off"));
        }
    }
}