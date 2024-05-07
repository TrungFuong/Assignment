public class Member { //Create the Member Class
    public string FirstName;
    public string LastName;
    public char Gender;
    public DateOnly DOB;
    public string PhoneNumber;
    public string BirthPlace;
    public int Age;
    public bool IsGraduated;

    //Create the Member Constructor
    public Member(string FirstName, string LastName, char Gender, DateOnly DOB, string PhoneNumber, string BirthPlace, int Age, bool IsGraduated)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Gender = Gender;
        this.DOB = DOB;
        this.PhoneNumber = PhoneNumber;
        this.BirthPlace = BirthPlace;
        this.Age = Age;
        this.IsGraduated = IsGraduated;
    }

    //object --> ToString
     public override string ToString()
    {
        return $"Name: {FirstName} {LastName}, Gender: {Gender}, DOB: {DOB}, Phone Number: {PhoneNumber}, Birth Place: {BirthPlace}, Age: {Age}, Is Graduated: {IsGraduated}";
    }
}