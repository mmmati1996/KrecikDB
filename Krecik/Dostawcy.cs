
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
    
public partial class Dostawcy
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Dostawcy()
    {

        this.Dostawy = new HashSet<Dostawy>();

        this.Magazyn_glowny = new HashSet<Magazyn_glowny>();

    }


    public int Id_dostawcy { get; set; }

    public string Nazwa_pelna { get; set; }

    public string Nazwa_skrocona { get; set; }

    public string Imie { get; set; }

    public string Nazwisko { get; set; }

    public string Adres { get; set; }

    public string NIP { get; set; }

    public string Uwagi { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Dostawy> Dostawy { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Magazyn_glowny> Magazyn_glowny { get; set; }

}

}
