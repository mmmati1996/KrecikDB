
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Krecik
{

using System;
    using System.Collections.Generic;
    
public partial class Kategorie_produktow
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Kategorie_produktow()
    {

        this.Magazyn_glowny = new HashSet<Magazyn_glowny>();

        this.Identyfikatory_produktow = new HashSet<Identyfikatory_produktow>();

    }


    public int Id_kategorii { get; set; }

    public string Kategoria_nadrzedna { get; set; }

    public string Opis_kategorii { get; set; }

    public string Nazwa_cechy { get; set; }

    public string Wartość_cechy { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Magazyn_glowny> Magazyn_glowny { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Identyfikatory_produktow> Identyfikatory_produktow { get; set; }

}

}
