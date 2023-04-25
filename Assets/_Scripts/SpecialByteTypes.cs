using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpecialByteTypes
{

    public static HashSet<int> specialCornerUpLeft = new HashSet<int>
    {
        0b00111000,
        0b01111000,
        0b01111100,
        0b00111100
    };

    public static HashSet<int> specialCornerUpRight = new HashSet<int>
    {
        0b00011111,
        0b00001110,
        0b00011110,
        0b00001111,
        0b00011011,
        0b01001111
    };

    public static HashSet<int> specialCornerDownLeft = new HashSet<int>
    {
        0b11100000,
        0b11110000,
        0b11100001,
        0b11110001,
        0b10110100
    };

    public static HashSet<int> specialCornerDownRight = new HashSet<int>
    {
        0b10000011,
        0b10000111,
        0b11000011,
        0b11000111
    };

    public static HashSet<int> specialTop = new HashSet<int>
    {
        0b00111110,
        0b00111111,
        0b01111110,
        0b01111111
    };

    public static HashSet<int> specialBottom = new HashSet<int>
    {
        0b11100011,
        0b11100111,
        0b11110011,
        0b11110111
    };

    public static HashSet<int> specialLeft = new HashSet<int>
    {
        0b11111000,
        0b11111100,
        0b11111001,
        0b11111101
    };

    public static HashSet<int> specialRight = new HashSet<int>
    {
        0b10001111,
        0b11011111,
        0b11001111,
        0b10011111
    };

    public static HashSet<int> specialFull = new HashSet<int>
    {
        0b11111111
    };

    public static HashSet<int> specialSingle = new HashSet<int>
    {
        0b00000000,
        0b00000001,
        0b01000000,
        0b00010000,
        0b00000100,
        0b00000101,
        0b00010001,
        0b01000100,
        0b01010101,
        0b01000001,
        0b01010000,
        0b00010100
    };

    public static HashSet<int> specialLongHorizontal = new HashSet<int>
    {
        0b01110111,
        0b00100010,
        0b01100010,
        0b01100011,
        0b00110110,
        0b00100011,
        0b00100110,
        0b00110010,
        0b01110010,
        0b00110111,
        0b01110110,
        0b00100111,
        0b00110011,
        0b01110011,
        0b01100111,
        0b01100110
    };

    public static HashSet<int> specialLongVertical = new HashSet<int>
    {
        0b11011101,
        0b10001101,
        0b10011000,
        0b10001000,
        0b11011000,
        0b11001000,
        0b10001001,
        0b10001100,
        0b11001001,
        0b11011100,
        0b10011100,
        0b11011001,
        0b11001100,
        0b11001101,
        0b10011101,
        0b10011001
    };

    public static HashSet<int> specialLongCornerUpLeft = new HashSet<int>
    {
        0b01101100,
        0b00101100,
        0b01101000,
        0b00101000
    };

    public static HashSet<int> specialLongCornerUpRight = new HashSet<int>
    {
        0b00011011,
        0b00001011,
        0b00011010,
        0b00001010,
        0b01011011,
        0b00011011,
        0b00011010,
        0b00001010,
        0b00001011,
        0b00001010,
        0b00011010
    };

    public static HashSet<int> specialLongCornerDownLeft = new HashSet<int>
    {
        0b10100000,
        0b10100001,
        0b10110000,
        0b10110001
    };

    public static HashSet<int> specialLongCornerDownRight = new HashSet<int>
    {
        0b10000010,
        0b10000110,
        0b11000010,
        0b11000110
    };

    public static HashSet<int> specialLongEndTop = new HashSet<int>
    {
        0b00011100,
        0b00001000,
        0b00001100,
        0b00011000
    };

    public static HashSet<int> specialLongEndDown = new HashSet<int>
    {
        0b10000001,
        0b11000000,
        0b10000000,
        0b11000001,
        0b10000101
    };

    public static HashSet<int> specialLongEndLeft = new HashSet<int>
    {
        0b01100000,
        0b00110000,
        0b00100000,
        0b01110000
    };

    public static HashSet<int> specialLongEndRight = new HashSet<int>
    {
        0b00000111,
        0b00000010,
        0b00000011,
        0b00000110,
        0b01000110,
        0b00010011
    };

    public static HashSet<int> specialTopInnerBottom = new HashSet<int>
    {
        0b01101011,
        0b00101010,
        0b00101011,
        0b01101010
    };

    public static HashSet<int> specialBottomInnerTop = new HashSet<int>
    {
        0b10100110,
        0b10110010,
        0b10100010,
        0b10110110
    };

    public static HashSet<int> specialLeftInnerRight = new HashSet<int>
    {
        0b10101101,
        0b10101000,
        0b10101100,
        0b10101001
    };

    public static HashSet<int> specialRightInnerLeft = new HashSet<int>
    {
        0b11011010,
        0b10001010,
        0b11001010,
        0b10011010
    };

    public static HashSet<int> specialInnerBottom = new HashSet<int>
    {
        0b11101011
    };

    public static HashSet<int> specialInnerTop = new HashSet<int>
    {
        0b10111110
    };

    public static HashSet<int> specialInnerLeft = new HashSet<int>
    {
        0b11111010
    };

    public static HashSet<int> specialInnerRight = new HashSet<int>
    {
        0b10101111
    };

    public static HashSet<int> specialInnerDownRight = new HashSet<int>
    {
        0b11101111
    };

    public static HashSet<int> specialInnerDownLeft = new HashSet<int>
    {
        0b11111011
    };

    public static HashSet<int> specialInnerUpLeft = new HashSet<int>
    {
        0b11111110
    };

    public static HashSet<int> specialInnerUpRight = new HashSet<int>
    {
        0b10111111
    };

    public static HashSet<int> specialLeftInnerDownRight = new HashSet<int>
    {
        0b11101000,
        0b11101101,
        0b11101100,
        0b11101001
    };

    public static HashSet<int> specialRightInnerUpLeft = new HashSet<int>
    {
        0b10011110,
        0b11001110,
        0b11011110,
        0b10001110
    };

    public static HashSet<int> specialBottomInnerUpRight = new HashSet<int>
    {
        0b10110111,
        0b10100111,
        0b10100011,
        0b10110011
    };

    public static HashSet<int> specialTopInnerDownLeft = new HashSet<int>
    {
        0b00111011,
        0b00111010,
        0b01111010,
        0b01111011
    };

    public static HashSet<int> specialLeftInnerUpRight = new HashSet<int>
    {
        0b10111000,
        0b10111101,
        0b10111100,
        0b10111001
    };

    public static HashSet<int> specialBottomInnerUpLeft = new HashSet<int>
    {
        0b11100110,
        0b11110010,
        0b11110110,
        0b11100010
    };

    public static HashSet<int> specialTopInnerDownRight = new HashSet<int>
    {
        0b00101110,
        0b01101111,
        0b00101111,
        0b01101110
    };

    public static HashSet<int> specialRightInnerDownLeft = new HashSet<int>
    {
        0b10011011,
        0b11001011,
        0b11011011,
        0b10001011
    };

    public static HashSet<int> specialInnerDiagUpLeft = new HashSet<int>
    {
        0B10111010
    };

    public static HashSet<int> specialInnerDiagUpRight = new HashSet<int>
    {
        0b10101110
    };

    public static HashSet<int> specialInnerDiagDownLeft = new HashSet<int>
    {
        0b11101010
    };

    public static HashSet<int> specialInnerDiagDownRight = new HashSet<int>
    {
        0b10101011
    };

    public static HashSet<int> specialDiagUpLeftDownRight = new HashSet<int>
    {
        0b11101110
    };

    public static HashSet<int> specialDiagDownLeftUpRight = new HashSet<int>
    {
        0b10111011
    };
}
