namespace Request
{
    [System.Serializable]
    public struct PostData
    {
        public string title;
        public string message;
        public UserResult user;
        public int data;
    }
}