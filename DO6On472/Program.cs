using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using DO6SharedModel;
using Xtensive.Orm;
using Xtensive.Orm.Services;
using Xtensive.Sql.Compiler;

namespace DO6On472
{
  internal class Program
  {
    static void Main(string[] args)
    {
      BenchmarkDotNet.Running.BenchmarkRunner.Run<QueryFormatterTranslationBenchmark>();
      BenchmarkDotNet.Running.BenchmarkRunner.Run<QueryBuilderTranslationBenchmark>();
      BenchmarkDotNet.Running.BenchmarkRunner.Run<QueryBuilderStepOneBenchmark>();
      BenchmarkDotNet.Running.BenchmarkRunner.Run<QueryBuilderStepTwoBenchmark>();
      BenchmarkDotNet.Running.BenchmarkRunner.Run<QueryBuilderStepThreeBenchmark>();
      BenchmarkDotNet.Running.BenchmarkRunner.Run<QueryBuilderStepFourBenchmark>();
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  [RankColumn]
  public class QueryFormatterTranslationBenchmark : TranslationBenchmarkBase
  {
    private QueryFormatter formatter;

    public override void BeforeEveryIteration()
    {
      base.BeforeEveryIteration();
      formatter = session.Services.GetService<QueryFormatter>();
    }

    public override void AfterEveryIteration()
    {
      formatter = null;
      base.AfterEveryIteration();
    }

    [Benchmark]
    public void CompileWithQueryInside()
    {
      _ = queryRunner.MakeEntireCompilation(formatter);
    }

    [Benchmark]
    public void CompileWithQueryOutside()
    {
      _ = queryRunner.MakeEntireCompilation(formatter, cachedQuery);
    }

    public QueryFormatterTranslationBenchmark() : base()
    {
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  [RankColumn]
  public class QueryBuilderTranslationBenchmark : TranslationBenchmarkBase
  {
    private QueryBuilder queryBuilder;

    public override void BeforeEveryIteration()
    {
      base.BeforeEveryIteration();
      queryBuilder = session.Services.GetService<QueryBuilder>();
    }

    public override void AfterEveryIteration()
    {
      queryBuilder = null;
      base.AfterEveryIteration();
    }

    [Benchmark]
    public void TranslateOnly()
    {
      _ = queryRunner.Translate(queryBuilder, cachedQuery);
    }

    [Benchmark]
    public void TranslateAndCompile()
    {
      _ = queryRunner.TranslateAndCompile(queryBuilder, cachedQuery);
    }

    [Benchmark]
    public void TranslateCompileCreateRequest()
    {
      _ = queryRunner.TranslateCompileAndCreateRequest(queryBuilder, cachedQuery);
    }

    [Benchmark]
    public void TranslateCompileCreateRequestAndCommand()
    {
      _ = queryRunner.TranslateCompileCreateRequestAndCommand(queryBuilder, cachedQuery);
    }

    public QueryBuilderTranslationBenchmark() : base()
    {
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  [RankColumn]
  public class QueryBuilderStepOneBenchmark : TranslationBenchmarkBase
  {
    private QueryBuilder queryBuilder;

    public override void BeforeEveryIteration()
    {
      base.BeforeEveryIteration();
      queryBuilder = session.Services.GetService<QueryBuilder>();
    }

    public override void AfterEveryIteration()
    {
      queryBuilder = null;
      base.AfterEveryIteration();
    }

    [Benchmark]
    public void Translate()
    {
      _ = queryRunner.Translate(queryBuilder, cachedQuery);
    }

    public QueryBuilderStepOneBenchmark() : base()
    {
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  [RankColumn]
  public class QueryBuilderStepTwoBenchmark : TranslationBenchmarkBase
  {
    private QueryBuilder queryBuilder;
    private QueryTranslationResult translationResult;

    public override void BeforeEveryIteration()
    {
      base.BeforeEveryIteration();
      queryBuilder = session.Services.GetService<QueryBuilder>();
      translationResult = queryBuilder.TranslateQuery(cachedQuery);
    }

    public override void AfterEveryIteration()
    {
      queryBuilder = null;
      translationResult = null;
      base.AfterEveryIteration();
    }

    [Benchmark]
    public void CompileTranslated()
    {
      _ = queryRunner.CompileTranslated(queryBuilder, translationResult);
    }

    public QueryBuilderStepTwoBenchmark() : base()
    {
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  [RankColumn]
  public class QueryBuilderStepThreeBenchmark : TranslationBenchmarkBase
  {
    private QueryBuilder queryBuilder;
    private QueryTranslationResult translationResult;
    private SqlCompilationResult sqlCompilationResult;

    public override void BeforeEveryIteration()
    {
      base.BeforeEveryIteration();
      queryBuilder = session.Services.GetService<QueryBuilder>();
      translationResult = queryBuilder.TranslateQuery(cachedQuery);
      sqlCompilationResult = queryBuilder.CompileQuery(translationResult.Query);
    }

    public override void AfterEveryIteration()
    {
      queryBuilder = null;
      sqlCompilationResult = null;
      translationResult = null;
      base.AfterEveryIteration();
    }

    [Benchmark]
    public void CreateRequest()
    {
      _ = queryRunner.CreateRequest(queryBuilder, sqlCompilationResult, translationResult.ParameterBindings);
    }

    public QueryBuilderStepThreeBenchmark() : base()
    {
    }
  }

  [MemoryDiagnoser]
  [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.Declared)]
  [RankColumn]
  public class QueryBuilderStepFourBenchmark : TranslationBenchmarkBase
  {
    private QueryBuilder queryBuilder;
    private QueryTranslationResult translationResult;
    private SqlCompilationResult sqlCompilationResult;
    private QueryRequest request;

    public override void BeforeEveryIteration()
    {
      base.BeforeEveryIteration();
      queryBuilder = session.Services.GetService<QueryBuilder>();
      translationResult = queryBuilder.TranslateQuery(cachedQuery);
      sqlCompilationResult = queryBuilder.CompileQuery(translationResult.Query);
      request = queryRunner.CreateRequest(queryBuilder, sqlCompilationResult, translationResult.ParameterBindings);
    }

    public override void AfterEveryIteration()
    {
      queryBuilder = null;
      request = null;
      sqlCompilationResult = null;
      translationResult = null;
      base.AfterEveryIteration();
    }

    [Benchmark]
    public void CreateQueryCommand()
    {
      _ = queryRunner.CreateQueryCommand(queryBuilder, request);
    }

    public QueryBuilderStepFourBenchmark() : base()
    {
    }
  }

  public abstract class TranslationBenchmarkBase
  {
    protected readonly QueryRunner queryRunner;

    protected Domain domain;
    protected Session session;
    protected TransactionScope tx;

    protected IQueryable<VehicleDto> cachedQuery;

    [GlobalSetup]
    public virtual void GlobalSetup()
    {
      domain = Domain.Build(
        DomainConfigurationFactory.CreateDomainConfiguration());
    }

    [GlobalCleanup]
    public virtual void GlobalCleanup()
    {
      domain.Dispose();
    }

    [IterationSetup]
    public virtual void BeforeEveryIteration()
    {
      session = domain.OpenSession();
      tx = session.OpenTransaction();
      cachedQuery = QueryRunner.MakeQuery(session);
    }

    [IterationCleanup]
    public virtual void AfterEveryIteration()
    {
      tx.Dispose();
      session.Dispose();
    }

    public TranslationBenchmarkBase()
    {
      queryRunner = new QueryRunner();
    }
  }
}
