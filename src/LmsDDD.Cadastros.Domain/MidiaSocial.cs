using LmsDDD.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace LmsDDD.Cadastros.Domain
{
    public class MidiaSocial
    {
        public string UrlSite { get; private set; }
        public string UrlLinkedin { get; private set; }
        public string UrlFacebook { get; private set; }
        public string UrlInstagram { get; private set; }
        public string UrlYoutube { get; private set; }

        #region Construtores
        public MidiaSocial(string urlSite,string urlLinkedin,string urlFacebook,string urlInstagram,string urlYoutube)
        {
            UrlSite = urlSite;
            UrlLinkedin = urlLinkedin;
            UrlFacebook = urlFacebook;
            UrlInstagram = urlInstagram;
            UrlYoutube = urlYoutube;
            Validar();
        }

        #endregion
        #region Validação
        //garantir que o curso para garantir o curso se esta consistente ou nao, dica de boa pratica

        public void Validar()
        {
            if(!string.IsNullOrEmpty(UrlSite))
                Validacoes.ValidarUrl(UrlSite, "O campo UrlSite não pode estar inválida!");
            if (!string.IsNullOrEmpty(UrlYoutube))
                Validacoes.ValidarUrl(UrlYoutube, "O campo UrlYoutube não pode estar inválida!");
            if (!string.IsNullOrEmpty(UrlFacebook))
                Validacoes.ValidarUrl(UrlFacebook, "O campo UrlFacebook não pode estar inválida!");
            if (!string.IsNullOrEmpty(UrlInstagram))
                Validacoes.ValidarUrl(UrlInstagram, "O campo UrlInstagram não pode estar inválida!");
            if (!string.IsNullOrEmpty(UrlLinkedin))
                Validacoes.ValidarUrl(UrlLinkedin, "O campo UrlLinkedin não pode estar inválida!");
        }

        #endregion
    }
}
