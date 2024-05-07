internal class Program
{
    public static List<Member> GetMaleMembers(List<Member> Members)
    //Where member.gender == 'M'--> add to list
    {
        List<Member> MaleMembers = Members.Where(member => member.Gender == 'M').ToList();

        //Print the list 
        foreach (Member maleMember in MaleMembers)
        {
            Console.WriteLine(maleMember);
        }
        return MaleMembers;
    }

    public static Member GetOldestMember(List<Member> Members)
    //OrderBy -> get first
    {
        var oldestMember = Members.OrderByDescending(member => member.Age).First();
        return oldestMember;
    }

    /// <summary>
    /// Get the full names of members from a list of Member obj
    /// </summary>
    /// <param name="Members">The list of Member objects.</param>
    /// <returns>A list of strings representing the full names of the members</returns>
    public static List<string> GetFullName(List<Member> Members)
    {
        List<string> FullNames = Members.Select(member => member.FirstName + " " + member.LastName).ToList();

        foreach (string member in FullNames)
        {
            Console.WriteLine(member);
        }
        return FullNames;
    }

    /// <summary>
    /// Get a list of member who were born in 2000 from a list of Member obj
    /// </summary>
    /// <param name="Members"></param>
    /// <returns>A list of member where Year == 2000</returns>
    public static List<Member> GetMembers2k(List<Member> Members)
    {
        List<Member> Members2k = Members.Where(member => member.DOB.Year == 2000).ToList();
        
        return Members2k;
    }

    /// <summary>
    /// Get a list of member who were born before 2000 from a list of Member obj
    /// </summary>
    /// <param name="Members"></param>
    /// <returns>A list of member where Year < 2000</returns>
    public static List<Member> GetMembersBefore2k(List<Member> Members)
    {
        List<Member> MembersBefore2k = Members.Where(member => member.DOB.Year < 2000).ToList();
        return MembersBefore2k;
    }

    /// <summary>
    /// Get a list of member who were born after 2000 from a list of Member obj
    /// </summary>
    /// <param name="Members"></param>
    /// <returns>A list of member with DOB.Year > 2000</returns>
    public static List<Member> GetMembersAfter2k(List<Member> Members)
    {
        List<Member> MembersAfter2k =Members.Where(member => member.DOB.Year > 2000).ToList();
        return MembersAfter2k;
    }

    public static Member? GetHanoiMembers(List<Member> Members)
    {
        var memberHanoi = Members.Where(member => string.Equals(member.BirthPlace, "Ha Noi", StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        return memberHanoi; 
    }

    public static void Main(string[] args)
    {
        List<Member> Members = new List<Member>{
        new("A", "A", 'M', new DateOnly(2000, 12, 1), "123", "Hai Phong", 24, true),
        new("B", "B", 'F', new DateOnly(2001, 12, 2), "234", "Hue", 24, true),
        new("C", "C", 'M', new DateOnly(2002, 12, 3), "345", "Da Nang", 22, true),
        new("D", "D", 'M', new DateOnly(2003, 12, 4), "456", "Ha Noi", 21, false),
        new("E", "E", 'F', new DateOnly(2001, 12, 5), "567", "Quy Nhon", 23, true),
        new("F", "F", 'F', new DateOnly(2002, 12, 6), "678", "Ha Noi", 22, false),
        new("G", "G", 'M', new DateOnly(1999, 12, 7), "789", "Bac Ninh", 25, true),
        new("H", "H", 'M', new DateOnly(2000, 12, 8), "890", "Nam Dinh", 24, true),
        new("I", "I", 'F', new DateOnly(2004, 12, 9), "901", "Ha Noi", 20, false),
        new("I", "I", 'F', new DateOnly(2003, 12, 10), "012", "Quang Ninh", 21, true)
        };

        //Menu
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Get male members");
        Console.WriteLine("2. Get the oldest member");
        Console.WriteLine("3. Get a fullname list of all members");
        Console.WriteLine("4. Get lists of all members who were born in 2000, before 2000, and after 2000");
        Console.WriteLine("5. Get a member from Ha Noi");
        Console.WriteLine("0. Exit");
        Console.Write("Enter your option: ");
        int option = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        switch (option)
        {
            case 1:
                GetMaleMembers(Members);
                break;
            case 2:
                Member oldestMember = GetOldestMember(Members);
                Console.WriteLine("The oldest member is: " + oldestMember);
                break;
            case 3:
                List<string> FullNames = GetFullName(Members);
                foreach (string FullName in FullNames)
                {
                    Console.WriteLine(FullName);
                }
                break;
            case 4:
                Console.WriteLine("1. Get members who were born in 2000");
                Console.WriteLine("2. Get members who were born before 2000");
                Console.WriteLine("3. Get members who were born after 2000");
                int miniOption = Convert.ToInt32(Console.ReadLine());
                switch (miniOption)
                {
                    case 1:
                        List<Member> Members2k = GetMembers2k(Members);
                        Console.WriteLine("Members who were born in 2000: ");
                        foreach (Member member in Members2k)
                        {
                            Console.WriteLine(member);
                        }
                        break;
                    case 2:
                        List<Member> MembersBefore2k = GetMembersBefore2k(Members);
                        Console.WriteLine("Members who were born before 2000: ");
                        foreach (Member member in MembersBefore2k)
                        {
                            Console.WriteLine(member);
                        }
                        break;
                    case 3:
                        List<Member> MembersAfter2k = GetMembersAfter2k(Members);
                        Console.WriteLine("Members who were born after 2000: ");
                        foreach (Member member in MembersAfter2k)
                        {
                            Console.WriteLine(member);
                        }
                        break;
                }
                break;
            case 5:
                Member memberHanoi = GetHanoiMembers(Members);
                if (memberHanoi != null)
                {
                    Console.WriteLine("The first member from Ha Noi: " + memberHanoi);
                }
                else
                {
                    Console.WriteLine("No member from Ha Noi");
                }
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }
    }
}