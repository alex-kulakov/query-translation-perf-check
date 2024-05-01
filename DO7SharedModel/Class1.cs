using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Xtensive.Orm;
using Xtensive.Orm.Configuration;
using Xtensive.Orm.Services;
using Xtensive.Sql.Compiler;

namespace DO7SharedModel
{
  #region Enums
  public enum ContactType : byte
  {
    Address,
    PhoneNumber,
    EmailAddress
  }

  public enum VehicleType
  {
    Car,
    Truck,
    Boat,
    Ship,
    PersonalMobilityDevice
  }

  public enum EnergySource
  {
    DieselFuel,
    Gasoline,
    NaturalGas,
    Electricity,
    LiquidHydrogen
  }
  #endregion

  #region Interfaces

  public interface IVehicle : IEntity
  {
    [Field, Key]
    long Id { get; }

    [Field]
    DateTime Timestamp { get; }

    [Field]
    Person Owner { get; set; }

    [Field]
    VehicleManufacturer Manufacturer { get; }

    [Field]
    VehicleRegistrationInfo RegistrationInfo { get; }

    [Field]
    string ModelName { get; }

    [Field]
    string VinNumber { get; }

    [Field]
    double EnginePower { get; }

    [Field]
    EnergySource EnergySource { get; }

    [Field]
    VehicleType Type { get; }
  }

  public interface IImmovable : IEntity
  {
    [Field, Key]
    long Id { get; }

    [Field]
    string CadastralNumber { get; }

    [Field]
    Person Owner { get; }

    [Field]
    AddressInfo AddressIfExists { get; }
  }

  #endregion

  #region IVehicle implementations

  [HierarchyRoot]
  public class Car : Entity, IVehicle
  {
    [Field]
    public long Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field]
    public Person Owner { get; set; }

    [Field]
    public VehicleManufacturer Manufacturer { get; private set; }

    [Field]
    public VehicleRegistrationInfo RegistrationInfo { get; private set; }

    [Field]
    public string ModelName { get; private set; }

    [Field]
    public string VinNumber { get; private set; }

    [Field]
    public double EnginePower { get; private set; }

    [Field]
    public EnergySource EnergySource { get; private set; }

    [Field]
    public VehicleType Type { get; private set; }

    public Car(Session session,
      Person owner,
      VehicleManufacturer manufacturer,
      string modelName,
      string vinNumber,
      double enginePower,
      VehicleRegistrationInfo registrationInfo,
      EnergySource energySource)
      : base(session)
    {
      Timestamp = DateTime.UtcNow;
      Owner = owner;
      Manufacturer = manufacturer;
      ModelName = modelName;
      VinNumber = vinNumber;
      EnginePower = enginePower;
      RegistrationInfo = registrationInfo;
      EnergySource = energySource;
      Type = VehicleType.Car;
    }
  }

  [HierarchyRoot]
  public class Truck : Entity, IVehicle
  {
    [Field]
    public long Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field]
    public Person Owner { get; set; }

    [Field]
    public VehicleManufacturer Manufacturer { get; private set; }

    [Field]
    public VehicleRegistrationInfo RegistrationInfo { get; private set; }

    [Field]
    public string ModelName { get; private set; }

    [Field]
    public string VinNumber { get; private set; }

    [Field]
    public double EnginePower { get; private set; }

    [Field]
    public EnergySource EnergySource { get; private set; }

    [Field]
    public VehicleType Type { get; private set; }

    public Truck(Session session,
      Person owner,
      VehicleManufacturer manufacturer,
      string modelName,
      string vinNumber,
      double enginePower,
      VehicleRegistrationInfo registrationInfo,
      EnergySource energySource)
      : base(session)
    {
      Timestamp = DateTime.UtcNow;
      Owner = owner;
      Manufacturer = manufacturer;
      ModelName = modelName;
      VinNumber = vinNumber;
      EnginePower = enginePower;
      RegistrationInfo = registrationInfo;
      EnergySource = energySource;
      Type = VehicleType.Truck;
    }
  }

  [HierarchyRoot]
  public class Boat : Entity, IVehicle
  {
    [Field]
    public long Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field]
    public Person Owner { get; set; }

    [Field]
    public VehicleManufacturer Manufacturer { get; private set; }

    [Field]
    public VehicleRegistrationInfo RegistrationInfo { get; private set; }

    [Field]
    public string ModelName { get; private set; }

    [Field]
    public string VinNumber { get; private set; }

    [Field]
    public double EnginePower { get; private set; }

    [Field]
    public EnergySource EnergySource { get; private set; }

    [Field]
    public VehicleType Type { get; private set; }

    public Boat(Session session,
      Person owner,
      VehicleManufacturer manufacturer,
      string modelName,
      string vinNumber,
      double enginePower,
      VehicleRegistrationInfo registrationInfo,
      EnergySource energySource)
      : base(session)
    {
      Timestamp = DateTime.UtcNow;
      Owner = owner;
      Manufacturer = manufacturer;
      ModelName = modelName;
      VinNumber = vinNumber;
      EnginePower = enginePower;
      RegistrationInfo = registrationInfo;
      EnergySource = energySource;
      Type = VehicleType.Boat;
    }
  }

  [HierarchyRoot]
  public class Ship : Entity, IVehicle
  {
    [Field]
    public long Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field]
    public Person Owner { get; set; }

    [Field]
    public VehicleManufacturer Manufacturer { get; private set; }

    [Field]
    public VehicleRegistrationInfo RegistrationInfo { get; private set; }

    [Field]
    public string ModelName { get; private set; }

    [Field]
    public string VinNumber { get; private set; }

    [Field]
    public double EnginePower { get; private set; }

    [Field]
    public EnergySource EnergySource { get; private set; }

    [Field]
    public VehicleType Type { get; private set; }

    public Ship(Session session,
      Person owner,
      VehicleManufacturer manufacturer,
      string modelName,
      string vinNumber,
      double enginePower,
      VehicleRegistrationInfo registrationInfo,
      EnergySource energySource)
      : base(session)
    {
      Timestamp = DateTime.UtcNow;
      Owner = owner;
      Manufacturer = manufacturer;
      ModelName = modelName;
      VinNumber = vinNumber;
      EnginePower = enginePower;
      RegistrationInfo = registrationInfo;
      EnergySource = energySource;
      Type = VehicleType.Ship;
    }
  }

  [HierarchyRoot]
  public class PersonalMobilityDevice : Entity, IVehicle
  {
    [Field]
    public long Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field]
    public Person Owner { get; set; }

    [Field]
    public VehicleManufacturer Manufacturer { get; private set; }

    [Field]
    public VehicleRegistrationInfo RegistrationInfo { get; private set; }

    [Field]
    public string ModelName { get; private set; }

    [Field]
    public string VinNumber { get; private set; }

    [Field]
    public double EnginePower { get; private set; }

    [Field]
    public EnergySource EnergySource { get; private set; }

    [Field]
    public VehicleType Type { get; private set; }

    public PersonalMobilityDevice(Session session,
      Person owner,
      VehicleManufacturer manufacturer,
      string modelName,
      string vinNumber,
      double enginePower,
      VehicleRegistrationInfo registrationInfo,
      EnergySource energySource)
      : base(session)
    {
      Timestamp = DateTime.UtcNow;
      Owner = owner;
      Manufacturer = manufacturer;
      ModelName = modelName;
      VinNumber = vinNumber;
      EnginePower = enginePower;
      RegistrationInfo = registrationInfo;
      EnergySource = energySource;
      Type = VehicleType.PersonalMobilityDevice;
    }
  }

  #endregion

  #region IImmovable implementations

  [HierarchyRoot]
  public class Appartment : Entity, IImmovable
  {
    [Field]
    public long Id { get; private set; }

    [Field]
    public string CadastralNumber { get; private set; }

    [Field]
    public Person Owner { get; private set; }

    [Field]
    public AddressInfo AddressIfExists { get; private set; }

    public Appartment(Session session, string cadastralNumber, Person owner, AddressInfo addressInfo = null)
      : base(session)
    {
      CadastralNumber = cadastralNumber;
      Owner = owner;
      AddressIfExists = addressInfo;
    }
  }

  #endregion

  #region Other classes

  [HierarchyRoot]
  public sealed class VehicleManufacturer : Entity
  {
    [Field, Key]
    public long Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field]
    public string Name { get; private set; }

    [Field]
    public string Country { get; private set; }

    public VehicleManufacturer(Session session, string name)
      : base(session)
    {
      Name = name;
    }
  }

  [HierarchyRoot(Xtensive.Orm.Model.InheritanceSchema.SingleTable)]
  public abstract class ContactInfo : Entity
  {
    [Field, Key]
    public long Id { get; private set; }

    [Field]
    public ContactType ContactType { get; private set; }

    [Field]
    public string Value { get; private set; }

    [Field]
    [Association(PairTo = nameof(Person.Contacts))]
    public Person Owner { get; private set; }

    public ContactInfo(Session session,
      ContactType contactType,
      Person owner,
      string value)
      : base(session)
    {
      ContactType = contactType;
      Owner = owner;
      Value = value;
    }
  }

  public sealed class PhoneInfo : ContactInfo
  {
    [Field(Nullable = false)]
    public bool IsDefault { get; set; }

    public PhoneInfo(Session session, Person owner, string phoneNumber)
      : base(session, ContactType.PhoneNumber, owner, phoneNumber)
    {
    }
  }

  public sealed class EmailInfo : ContactInfo
  {
    [Field(Nullable = false)]
    public bool IsDefault { get; set; }

    public EmailInfo(Session session, Person owner, string email)
      : base(session, ContactType.EmailAddress, owner, email)
    {
    }
  }

  public sealed class AddressInfo : ContactInfo
  {
    [Field(Length = 10, Nullable = false)]
    public string PostCode { get; set; }

    [Field(Length = 70, Nullable = false)]
    public string Country { get; private set; }

    [Field(Length = 70, Nullable = false)]
    public string City { get; private set; }

    [Field(Length = 250, Nullable = false)]
    public string Address { get; set; }

    [Field(Nullable = false)]
    public bool IsDefault { get; set; }

    public AddressInfo(Session session,
      Person owner,
      string postCode,
      string country,
      string city,
      string address)
      : base(session, ContactType.Address, owner, null)
    {
      PostCode = postCode;
      Country = country;
      City = city;
      Address = address;
    }
  }

  [HierarchyRoot]
  public sealed class Person : Entity
  {
    [Field, Key]
    public int Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field(Length = 70, Nullable = false)]
    public string FirstName { get; set; }

    [Field(Length = 70, Nullable = false)]
    public string LastName { get; set; }

    [Field]
    public EntitySet<ContactInfo> Contacts { get; private set; }

    [Field]
    [Association(PairTo = "Owner")]
    public EntitySet<IVehicle> Vehicles { get; private set; }

    [Field]
    [Association(PairTo = "Owner")]
    public EntitySet<IImmovable> Immovables { get; private set; }
  }

  [HierarchyRoot]
  public sealed class VehicleRegistrationInfo : Entity
  {
    [Field, Key]
    public long Id { get; private set; }

    [Field]
    public DateTime Timestamp { get; private set; }

    [Field]
    [Association(PairTo = "RegistrationInfo")]
    public IVehicle Vehicle { get; private set; }

    [Field]
    public string LicensePlate { get; private set; }

    [Field]
    public AddressInfo RegistrationAddress { get; set; }

    public VehicleRegistrationInfo(Session session,
      IVehicle vehicle,
      string licensePlate,
      AddressInfo registrationAddress)
      : base(session)
    {
      Vehicle = vehicle;
      LicensePlate = licensePlate;
      RegistrationAddress = registrationAddress;
    }
  }

  #endregion

  #region Dtos

  public class VehicleDto
  {
    public long VehicleId { get; set; }
    public DateTime VehicleRecordTimestamp { get; set; }
    public string VehicleModelName { get; set; }
    public string VehicleVinNumber { get; set; }
    public EnergySource VehicleEngineSource { get; set; }
    public double VehicleEnginePower { get; set; }
    public VehicleType VehicleType { get; set; }
    public VehicleOwnerDto VehicleOwner { get; set; }
    public VehicleManufacturerDto VehicleManufacturer { get; set; }
    public VehicleRegistrationInfoDto VehicleRegistrationInfo { get; set; }
  }

  public class RegistrationAddressDto
  {
    public long AddressId { get; set; }
    public string AddressPostCode { get; set; }
    public string AddressCountry { get; set; }
    public string AddressCity { get; set; }
    public string AddressAddress { get; set; }
  }

  public class VehicleManufacturerDto
  {
    public long ManufacturerId { get; set; }
    public DateTime ManufacturerRecordTimeStamp { get; set; }
    public string ManufacturerName { get; set; }
    public string ManufacturerCountry { get; set; }
  }

  public class VehicleOwnerDto
  {
    public int OwnerId { get; set; }
    public DateTime OwnerRecordTimeStamp { get; set; }
    public string OwnerFirstName { get; set; }
    public string OwnerLastName { get; set; }
    public long NumberOfVehicles { get; set; }
    public long NumberOfImmovables { get; set; }
  }

  public class VehicleRegistrationInfoDto
  {
    public long RegistrationId { get; set; }
    public DateTime RegistrationRecordTimeStamp { get; set; }
    public string RegistrationLicensePlate { get; set; }
    public RegistrationAddressDto RegistrationAddress { get; set; }
  }

  #endregion

  public class DomainConfigurationFactory
  {
    public static string SqlServerConnectionUrl = "sqlserver://dotest:dotest@ALEXEYKULAKOVPC\\MSSQL2016/DO-Tests?MultipleActiveResultSets=True";

    public static DomainConfiguration CreateDomainConfiguration()
    {
      var configuration = new DomainConfiguration(SqlServerConnectionUrl);
      configuration.Types.Register(typeof(IVehicle).Assembly, typeof(IVehicle).Namespace);
      configuration.UpgradeMode = DomainUpgradeMode.Recreate;
      return configuration;
    }
  }

  public class QueryRunner
  {
    public DbCommand MakeEntireCompilation(QueryFormatter queryFormatter, IQueryable<VehicleDto> queryable)
    {
      return queryFormatter.ToDbCommand(queryable);
    }

    public DbCommand MakeEntireCompilation(QueryFormatter queryFormatter)
    {
      var session = queryFormatter.Session;

      var queryable = MakeQuery(session);

      return queryFormatter.ToDbCommand(queryable);
    }

    public QueryTranslationResult Translate(QueryBuilder queryBuilder, IQueryable<VehicleDto> queryable)
    {
      var session = queryBuilder.Session;

      return queryBuilder.TranslateQuery(queryable);
    }

    public SqlCompilationResult CompileTranslated(QueryBuilder queryBuilder, QueryTranslationResult translationResult)
    {
      return queryBuilder.CompileQuery(translationResult.Query);
    }

    public QueryRequest CreateRequest(QueryBuilder queryBuilder, SqlCompilationResult compilationResult, IList<QueryParameterBinding> bindings)
    {
      return queryBuilder.CreateRequest(compilationResult, bindings);
    }

    public QueryCommand CreateQueryCommand(QueryBuilder queryBuilder, QueryRequest request)
    {
      return queryBuilder.CreateCommand(request);
    }

    public SqlCompilationResult TranslateAndCompile(QueryBuilder queryBuilder, IQueryable<VehicleDto> queryable)
    {
      var translated = queryBuilder.TranslateQuery(queryable);

      return queryBuilder.CompileQuery(translated.Query);
    }

    public QueryRequest TranslateCompileAndCreateRequest(QueryBuilder queryBuilder, IQueryable<VehicleDto> queryable)
    {
      var translated = queryBuilder.TranslateQuery(queryable);

      var compiled = queryBuilder.CompileQuery(translated.Query);

      return queryBuilder.CreateRequest(compiled, translated.ParameterBindings);
    }

    public QueryCommand TranslateCompileCreateRequestAndCommand(QueryBuilder queryBuilder, IQueryable<VehicleDto> queryable)
    {
      var translated = queryBuilder.TranslateQuery(queryable);

      var compiled = queryBuilder.CompileQuery(translated.Query);

      var request = queryBuilder.CreateRequest(compiled, translated.ParameterBindings);

      return queryBuilder.CreateCommand(request);
    }

    public static IQueryable<VehicleDto> MakeQuery(Session session)
    {
      return session.Query.All<IVehicle>()
        .Where(iv => iv.EnergySource == EnergySource.DieselFuel
          || iv.EnergySource == EnergySource.Gasoline
          || iv.EnergySource == EnergySource.Electricity
          || iv.ModelName.StartsWith("A") || iv.ModelName.StartsWith("B") || iv.ModelName.StartsWith("C")
          || iv.ModelName.Contains("C") || iv.ModelName.Contains("D") || iv.ModelName.Contains("E")
          || iv.Type.In(IncludeAlgorithm.ComplexCondition, VehicleType.Car, VehicleType.Truck, VehicleType.Ship, VehicleType.PersonalMobilityDevice)
          || (iv.Id > 100 && iv.Id < 1_000_000)
          || (iv.Timestamp.Year - iv.Timestamp.Day) > 1500
          || (iv.Timestamp.AddDays(3) > DateTime.UtcNow)
        )
        .LeftJoin(
          session.Query.All<Person>()
            .Where(p => p.FirstName.Contains("A") || p.FirstName.Contains("B") || p.FirstName.Contains("C")
              || p.FirstName.StartsWith("D") || p.FirstName.StartsWith("Y") || p.FirstName.StartsWith("Z")
              || p.Immovables.Count > 0
              || (p.Id > 100 && p.Id < 1_000_000)
              || (p.Timestamp.Year - p.Timestamp.Day) > 1500
              || (p.Timestamp.AddDays(3) > DateTime.UtcNow)
              )
            ,
          iv => iv.Owner.Id,
          p => p.Id,
          (iv, p) => new { IVehicle = iv, VehicleOwner = p })
        .LeftJoin(
          session.Query.All<VehicleManufacturer>()
            .Where(vm => vm.Country.StartsWith("A") || vm.Country.StartsWith("B") || vm.Country.StartsWith("C")
              || vm.Country.Contains("C") || vm.Name.Contains("D") || vm.Name.Contains("Z")
              || (vm.Id > 100 && vm.Id < 1_000_000)
              || (vm.Timestamp.Year - vm.Timestamp.Day) > 1500
              || (vm.Timestamp.AddDays(3) > DateTime.UtcNow))
            ,
          a => a.IVehicle.Manufacturer.Id,
          vm => vm.Id,
          (a, vm) => new { IVehicle = a.IVehicle, VehicleOwner = a.VehicleOwner, VehicleManufacturer = vm })
        .LeftJoin(
          session.Query.All<VehicleRegistrationInfo>()
            .Where(ri => ri.LicensePlate.StartsWith("B")
              || ri.LicensePlate.StartsWith("C")
              || ri.LicensePlate.EndsWith("Z")
              || ri.LicensePlate.EndsWith("Y")
              || (ri.Id > 100 && ri.Id < 1_000_000)
              || (ri.Timestamp.Year - ri.Timestamp.Day) > 1500
              || (ri.Timestamp.AddDays(3) > DateTime.UtcNow))
            ,
          a => a.IVehicle.RegistrationInfo.Id,
          ri => ri.Id,
          (a, ri) => new { IVehicle = a.IVehicle, VehicleOwner = a.VehicleOwner, VehicleManufacturer = a.VehicleManufacturer, VehicleRegistrationInfo = ri })
        .LeftJoin(
          session.Query.All<AddressInfo>()
            .Where(ai => ai.City.Length > 5 || ai.Address.Length > 10 || ai.ContactType == ContactType.Address),
          a => a.VehicleRegistrationInfo.RegistrationAddress.Id,
          ra => ra.Id,
          (a, ra) => new {
            IVehicle = a.IVehicle,
            VehicleOwner = a.VehicleOwner,
            VehicleManufacturer = a.VehicleManufacturer,
            VehicleRegistrationInfo = a.VehicleRegistrationInfo,
            VehicleRegistractionAddress = ra
          })
        .Select(a => new VehicleDto
        {
          VehicleId = a.IVehicle.Id,
          VehicleRecordTimestamp = a.IVehicle.Timestamp,
          VehicleModelName = a.IVehicle.ModelName,
          VehicleVinNumber = a.IVehicle.VinNumber,
          VehicleEngineSource = a.IVehicle.EnergySource,
          VehicleEnginePower = a.IVehicle.EnginePower,
          VehicleType = a.IVehicle.Type,
          VehicleOwner = new VehicleOwnerDto
          {
            OwnerId = a.VehicleOwner.Id,
            OwnerRecordTimeStamp = a.VehicleOwner.Timestamp,
            OwnerFirstName = a.VehicleOwner.FirstName,
            OwnerLastName = a.VehicleOwner.LastName,
            NumberOfVehicles = a.VehicleOwner.Vehicles.Count,
            NumberOfImmovables = a.VehicleOwner.Immovables.Count,
          },
          VehicleManufacturer = new VehicleManufacturerDto
          {
            ManufacturerId = a.VehicleManufacturer.Id,
            ManufacturerRecordTimeStamp = a.VehicleManufacturer.Timestamp,
            ManufacturerName = a.VehicleManufacturer.Name,
            ManufacturerCountry = a.VehicleManufacturer.Country
          },
          VehicleRegistrationInfo = new VehicleRegistrationInfoDto
          {
            RegistrationId = a.VehicleRegistrationInfo.Id,
            RegistrationRecordTimeStamp = a.VehicleRegistrationInfo.Timestamp,
            RegistrationLicensePlate = a.VehicleRegistrationInfo.LicensePlate,
            RegistrationAddress = new RegistrationAddressDto
            {
              AddressId = a.VehicleRegistractionAddress.Id,
              AddressPostCode = a.VehicleRegistractionAddress.PostCode,
              AddressCountry = a.VehicleRegistractionAddress.Country,
              AddressCity = a.VehicleRegistractionAddress.City,
              AddressAddress = a.VehicleRegistractionAddress.Address
            }
          }
        });
    }
  }
}
