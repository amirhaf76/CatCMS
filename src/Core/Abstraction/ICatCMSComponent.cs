﻿namespace CMSCore.Abstraction
{
    public interface ICatCMSComponent : IStorable, IGeneratableToCode
    {
        public Guid Id { get; set; }

     
    }
}