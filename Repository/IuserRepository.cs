﻿using Entities;


namespace Repository
{
    public interface IuserRepository
    {
        Task<UsersTbl> addUser(UsersTbl user);
        Task<UsersTbl> getUserByEmailAndPassword(string email, string password);
        Task updateUser( UsersTbl value);
        //Task<User> getUserById(int id);
    }
}