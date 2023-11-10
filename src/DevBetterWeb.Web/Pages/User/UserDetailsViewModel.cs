﻿using System.Collections.Generic;
using Ardalis.GuardClauses;
using DevBetterWeb.Core.Entities;

namespace DevBetterWeb.Web.Pages.User;

public class UserDetailsViewModel
{
  public string? AboutInfo { get; set; }
  public string? AvatarUrl { get; set; }
  public string? BlogUrl { get; set; }
  public string? CodinGameUrl { get; set; }
  public string? DiscordUsername { get; set; }
  public string? LinkedInUrl { get; set; }
  public string? GithubUrl { get; set; }
	public string? MastodonUrl { get; set; }
  public string? OtherUrl { get; set; }
  public string? TwitchUrl { get; set; }
  public string? TwitterUrl { get; set; }
  public string? BlueskyUrl { get; set; }
  public string? YouTubeUrl { get; set; }

  public string? Name { get; set; }
  public string? Birthday { get; set; }
  public string? Address { get; set; }
  public string? PEFriendCode { get; set; }
  public string? PEBadgeURL { get; set; }
  public List<Book> BooksRead { get; set; } = new List<Book>();

  public UserDetailsViewModel()
  {
  }

  public UserDetailsViewModel(Member member)
  {
    Guard.Against.Null(member, nameof(member));

    // TODO: Get URL format string from central config location
    AvatarUrl = string.Format(DevBetterWeb.Core.Constants.AVATAR_IMGURL_FORMAT_STRING, member.UserId);
    BlogUrl = member.BlogUrl;
    CodinGameUrl = member.CodinGameUrl;
    GithubUrl = member.GitHubUrl;
    LinkedInUrl = member.LinkedInUrl;
		MastodonUrl = member.MastodonUrl;
    TwitchUrl = member.TwitchUrl;
    TwitterUrl = member.TwitterUrl;
    BlueskyUrl = member.BlueskyUrl;
    YouTubeUrl = member.YouTubeUrl;

    if (!(string.IsNullOrEmpty(YouTubeUrl)) && !(YouTubeUrl.Contains("?")))
    {
      YouTubeUrl = YouTubeUrl + "?sub_confirmation=1";
    }

    OtherUrl = member.OtherUrl;
    AboutInfo = member.AboutInfo;
    Birthday = member.Birthday?.ToString();
    Address = member.Address;
    Name = member.UserFullName();
    PEFriendCode = member.PEFriendCode;
    if (!(string.IsNullOrEmpty(member.PEUsername)))
    {
      PEBadgeURL = $"https://projecteuler.net/profile/{member.PEUsername}.png";
    }

    BooksRead = member.BooksRead!;
    DiscordUsername = member.DiscordUsername;
  }
}
