using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDMath
{
    static public float determinant(float[,] m_in)
    {
        float result = 0;

        result = m_in[0, 0] * (m_in[1, 1] * m_in[2, 2] - m_in[1, 2] * m_in[2, 1])
                    - m_in[0, 1] * (m_in[1, 0] * m_in[2, 2] - m_in[1, 2] * m_in[2, 0])
                    + m_in[0, 2] * (m_in[1, 0] * m_in[2, 1] - m_in[1, 1] * m_in[2, 0]);
        return result;

    }
}
