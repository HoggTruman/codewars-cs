// https://www.codewars.com/kata/5884a4642a8d88df67000026

namespace TheSocialNetwork;

using System;
using System.Collections.Generic;
using System.Linq;


public class SocialNetwork : ISocialNetwork
{
    public List<Member> Members { get; private set; } = [];

    // Adds a new member and returns the added member
    public IMember AddMember(string firstName, string lastName, string city, string country)
    {
        MemberProfile profile = new(firstName, lastName, city, country);
        Member member = new(profile);
        Members.Add(member);
        return member;
    }

    // Returns the member with the id
    public IMember? FindMemberById(int id)
    {
        return Members.FirstOrDefault(x => x.Id == id);
    }

    // Returns a list of members by searching all fields in the profile
    public IEnumerable<IMember> FindMember(string search)
    {
        return Members.Where(x => 
            x.Profile.Firstname.Contains(search) ||
            x.Profile.Lastname.Contains(search) ||
            x.Profile.City.Contains(search) ||
            x.Profile.Country.Contains(search));
    }

    // Total number of members currently in the social network
    public int MemberCount => Members.Count;
}


public class Member : IMember
{
    private readonly HashSet<IMember> _friends = [];
    private readonly HashSet<IMember> _pending = [];
    private List<Post> _posts = [];

    public int Id { get; } = IdGenerator.GetId<IMember>();
    public IMemberProfile Profile { get; }
    public IEnumerable<IMember> Friends { get { return _friends; } }
    public IEnumerable<IMember> Pending { get { return _pending; } }
    public IEnumerable<IPost> Posts { get { return _posts; } }

    public Member(IMemberProfile profile)
    {
        Profile = profile;
    }

    // Adds a friend request for this member. from - the member making the friend request 
    public void AddFriendRequest(IMember from)
    {
        if (from != this && !_friends.Contains(from))
        {
            _pending.Add(from);
        }        
    }

    // Confirms a pending friend request
    public void ConfirmFriend(IMember member)
    {
        if (_pending.Remove(member))
        {
            _friends.Add(member);
            Member newFriend = (Member)member;
            newFriend._friends.Add(this);
        }        
    }

    // Removes a pending friend request
    public void RemoveFriendRequest(IMember member)
    {
        _pending.Remove(member);
    }

    // Removes a friend
    public void RemoveFriend(IMember member)
    {
        _friends.Remove(member);
        Member toRemove = (Member)member;
        toRemove._friends.Remove(this);
    }

    // Returns a list of all friends. level - depth (1 - friends, 2 - friends of friends ...)
    public IEnumerable<IMember> GetFriends(int level = 1, IList<int> filter = null)
    {
        IEnumerable<IMember> friends = Friends;
        for (int depth = 2; depth <= level; ++depth)
        {
            IEnumerable<IMember> nextFriends = [];
            foreach(IMember friend in friends)
            {
                nextFriends = nextFriends.Union(friend.Friends);
            }
            
            friends = friends.Union(nextFriends);
        }

        return friends.Where(x => x != this).ToHashSet();
    }

    // Adds a new post to members feed
    public IPost AddPost(string message)
    {
        Post post = new(this, message);
        _posts.Add(post);
        return post;
    }

    // Removes the post with the id
    public void RemovePost(int id)
    {
        _posts = _posts.Where(x => x.Id != id).ToList();
    }

    // Returns members feed as a list of posts. Should also return posts of friends.
    public IEnumerable<IPost> GetFeed()
    {
        return _friends.SelectMany(x => x.Posts).Concat(Posts).OrderBy(x => x.Id).ToList();
    }
}


public class MemberProfile(string firstName, string lastName, string city, string country) : IMemberProfile
{
    public int MemberId { get; set; } = IdGenerator.GetId<IMemberProfile>();        
    public string Firstname { get; set; } = firstName;
    public string Lastname { get; set; } = lastName;
    public string City { get; set; } = city;
    public string Country { get; set; } = country;
}


public class Post(IMember member, string message) : IPost
{
    public int Id { get; set; } = IdGenerator.GetId<IPost>();
    public IMember Member { get; set; } = member;
    public string Message { get; set; } = message;
    public DateTime Date { get; set; } = DateTime.Now;
    public int Likes { get; set; } = 0;
}










public static class IdGenerator
{
    public static int GetId<T>() => 0;
}

public interface ISocialNetwork;
public interface IMember
{
    public IEnumerable<IPost> Posts { get; }
    public IEnumerable<IMember> Friends { get; }
    public IMemberProfile Profile { get; }

    public void RemoveFriend(IMember member);
    public void AddFriendRequest(IMember from);
    public void ConfirmFriend(IMember member);
}

public interface IMemberProfile
{
    public int MemberId { get; set; }     
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}

public interface IPost
{
    public int Id { get; set; }
}