namespace Carpet_Wizard;

public static class ConvertsExtended
{
    public static int BoolToInt(bool flag){
        if (flag){
            return 1;
        }

        return 0;
    }
}