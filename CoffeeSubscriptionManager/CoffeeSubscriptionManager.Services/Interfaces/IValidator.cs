namespace CoffeeSubscriptionManager.Services.Interfaces;
/// <summary>
/// Validates requests and sets the next Validator in the chain.
/// </summary>
/// <typeparam name="T">Type of Validator</typeparam>
public interface IValidator<T> where T : class
{
    /// <summary>
    /// Sets the next Validator.
    /// </summary>
    /// <param name="next">The next Validator</param>
    /// <returns></returns>
    IValidator<T> SetNext(IValidator<T> next);
    /// <summary>
    /// Checks the request against criteria and runs the next validator.
    /// </summary>
    /// <param name="request">Input to validate</param>
    void Validate(T request);
}
