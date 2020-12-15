using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace AUBNB.Web.Api.Base 
{
    /// <summary>
    /// Controlador Base do AUBNB.Web.API
    /// 
    /// Essa classe é responsável por prover propriedades e métodos úteis nos demais controllers 
    /// que vão possuir essa classe como pai (herança).
    /// 
    /// Ela também herda da classe ApiController, com isso, suas implementações já se tornam controllers da API.
    /// </summary>
    public class ApiControllerBase : ApiController
    {
        #region Handlers

        /// <summary>
        /// Manuseia o callback. Valida se é necessário retornar erro ou o próprio TSuccess
        /// </summary> 
        /// <typeparam name="TSuccess"></typeparam>
        /// <param name="func">É a função que irá retornar o valor para o payload</param>
        /// <returns></returns>
        protected IHttpActionResult HandleCallback<TSuccess>(TSuccess data)
        {
            return Ok(data);
        }

        /// <summary>
        /// Manuseia os dados que resultaram de uma query.
        /// </summary> 
        /// <typeparam name="TSource">Tipo de Origem</typeparam>
        /// <typeparam name="TResult">Tipo de Destino (ViewModel)</typeparam>
        /// <param name="callback">Objeto Try utilizado nas chamadas.</param>
        /// <returns></returns>
        protected IHttpActionResult HandleQuery<TSource, TResult>(TSource result)
        {
            return Ok(Mapper.Map<TSource, TResult>(result));
        }

        protected IHttpActionResult HandleQueryable<TSource, TResult>(IQueryable<TSource> query)
        {
            // Fazemos .ToList para obter os dados antes de converter (precisamos dos dados para conversão)
            // Após isso, é obtido um queryable dos resultdos convertendo para o tipo principal. Não há mais operação no banco.
            var dataQuery = query.ToList().AsQueryable().ProjectTo<TResult>();
            // Esse .ToList() é performado no ProjectTo e não mais no EF
            return Ok(dataQuery.ToList());
        }

        /// <summary>
        /// Retorna IHttpStatusCode de erro + erros da validação.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validationFailure">Erros de validação (ValidationFailure)</param>
        /// <returns>IHttpActionResult com os erros e status code padrão</returns>
        protected IHttpActionResult HandleValidationFailure<T>(IList<T> validationFailure)
            where T : ValidationFailure
        {
            return Content(HttpStatusCode.BadRequest, validationFailure);
        }

        #endregion
    }
}