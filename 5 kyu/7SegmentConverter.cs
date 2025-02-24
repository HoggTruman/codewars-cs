// https://www.codewars.com/kata/52a7099f8a4d9604bb000472

public class SevenSegmentConverter
{
    public static int SevenSegmentNumber(int number) 
    {
        return number switch
        {
            0 => 0b1111101,
            1 => 0b1010000,
            2 => 0b0110111,
            3 => 0b1010111,
            4 => 0b1011010,
            5 => 0b1001111,
            6 => 0b1101111,
            7 => 0b1010001,
            8 => 0b1111111,
            9 => 0b1011111,
            _ => -1
        };
    }  
}
