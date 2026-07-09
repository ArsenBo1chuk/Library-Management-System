using System;
using System.Collections.Generic;
using Library.Repositories;
using Library.Models;
using Library.Interface;
using Library.Utils;
using Library.Enums;
using System.Data.Common;

namespace Library.Services;

public class ReaderService
{
    private readonly IRepository<Reader> readerRepository;
    private readonly ILogger logger;

    public ReaderService(IRepository<Reader> repository, ILogger logg)
    {
        readerRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        logger = logg ?? throw new ArgumentNullException(nameof(logg));
    }

    public void RegisterReader(string name, int age, string email)
    {
        var NewReader = new Reader(name, age, email);
        readerRepository.Add(NewReader);
        logger.Info($"Reader {NewReader.Name} added. ID: {NewReader.Id}");
    }

    public bool RemoveReader(Guid id)
    {
        var reader = readerRepository.GetAll().FirstOrDefault(x => x.Id == id);
        if(reader is not null)
        {
            readerRepository.Remove(reader);
            return true;
        }
        return false;
    }

    public bool EditReader(Guid id, string name, int age, string email)
    {
        var reader = readerRepository.GetAll().FirstOrDefault(x => x.Id == id);
        if(reader is not null)
        {
            reader.Name = name;
            reader.Age = age;
            reader.Email = email;
            return true;
        }
        return false;
    }

    public Reader? FindREader(Guid id)
    {
        return readerRepository.GetAll().FirstOrDefault(x => x.Id == id);
    }

    public List<Reader> GetAllReaders()
    {
        return readerRepository.GetAll();
    }

    public List<Reader> GetReadersWithPenalty()
    {
        return readerRepository.GetAll().Where(x => x.penaltyMoney > 0).ToList();
    }

    public List<Reader> GetTopReaders()
    {
        return readerRepository.GetAll().OrderByDescending(x => x.BorrowHistory.Count).ToList();
    }


    public void PrintReader(Guid id)
    {
        var reader = readerRepository.GetAll().FirstOrDefault(x => x.Id == id);
        if(reader is not null)
        {
            reader.PrintInfo();
        }
        else
        {
            throw new ArgumentException($"Reader with id {id} does not exist.");
        }
    }
}
