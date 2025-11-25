using bsbo_01_23_team4_var2_bibl2.Repository;

namespace bsbo_01_23_team4_var2_bibl2.UseCases;

public abstract class BaseUseCase
{
    protected readonly ILibraryRepository repository;

    protected BaseUseCase(ILibraryRepository repo)
    {
        repository = repo;
    }

    public abstract void Execute();
}