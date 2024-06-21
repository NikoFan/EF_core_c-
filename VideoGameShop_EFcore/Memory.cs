using System;

namespace VideoGameShop
{
    public static class Memory
    {
        static private int AccountId = -1;
        static private int VideoGameId = -1;
        static private int VideoGameCost = 0;

        static public int getAccountId() => AccountId;

        static public void setAccountId(int activeAccountIdNumber) => AccountId = activeAccountIdNumber;

        static public int  getVideoGameId() => VideoGameId;

        static public void setVideoGameId(int videoGameIdNumber) => VideoGameId = videoGameIdNumber;

        static public int getVideoGameCost() => VideoGameCost;

        static public void setVideoGameCost(int videoGameCostNumber) => VideoGameCost = videoGameCostNumber;
    }
}