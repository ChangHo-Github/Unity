using System;

[Serializable]
public class SendMessage
{
    public string type;
    public string regionNo;
    public string channelNo;
    public string userCodeNo;
    public string sender;
    public string message;
    public string wordlNickName;
    public UserLocation userLocation;

    public SendMessage(string type, string regionNo, string channelNo, string userCodeNo, string sender, string message, string wordlNickName, UserLocation userLocation)
    {
        this.type = type;
        this.regionNo = regionNo;
        this.channelNo = channelNo;
        this.userCodeNo = userCodeNo;
        this.sender = sender;
        this.message = message;
        this.wordlNickName = wordlNickName;
        this.userLocation = userLocation;
    }
}

[Serializable]
public class UserLocation
{
    public int userLocationNo;
    public int userPosX;
    public int userPosY;
    public int userPosZ;
    public int userRotY;
    public int motionStatus;

    public UserLocation(int userLocationNo, int userPosX, int userPosY, int userPosZ, int userRotY, int motionStatus)
    {
        this.userLocationNo = userLocationNo;
        this.userPosX = userPosX;
        this.userPosY = userPosY;
        this.userPosZ = userPosZ;
        this.userRotY = userRotY;
        this.motionStatus = motionStatus;
    }
}