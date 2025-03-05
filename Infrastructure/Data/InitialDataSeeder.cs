using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Infrastructure.Data
{
    public static class InitialDataSeeder
    {
        public static Product[] GetProducts()
        {
            return [
                new Product { Id = 1, Name = "Ibanez RG 350DX", Price = 399.99m, ImgUri = "ibanez_rg_350.jpg", Description = "Elektrická kytara." },
                new Product { Id = 2, Name = "Line 6 Helix Rack", Price = 1199.99m, ImgUri = "line6_helix_rack.jpg", Description = "Kytarový, digitální multi-efektový procesor montovatelný do 19'' racku." },
                new Product { Id = 3, Name = "Fender Stratocaster", Price = 599.99m, ImgUri = "fender_stratocaster.jpg", Description = "Legendární elektrická kytara." },
                new Product { Id = 4, Name = "Gibson Les Paul Standard", Price = 2499.99m, ImgUri = "gibson_les_paul.jpg", Description = "Klasická elektrická kytara s hlubokým tónem." },
                new Product { Id = 5, Name = "Marshall JVM410H", Price = 1199.99m, ImgUri = "marshall_jvm410h.jpg", Description = "Vysokovýkonný kytarový zesilovač." },
                new Product { Id = 6, Name = "Orange Rockerverb 50", Price = 999.99m, ImgUri = "orange_rockerverb.jpg", Description = "Zesilovač s vynikajícím tónem pro metal." },
                new Product { Id = 7, Name = "Sennheiser HD 600", Price = 299.99m, ImgUri = "sennheiser_hd600.jpg", Description = "Vysokokvalitní sluchátka pro audiofily." },
                new Product { Id = 8, Name = "Shure SM58", Price = 99.99m, ImgUri = "shure_sm58.jpg", Description = "Profesionální mikrofon pro zpěv." },
                new Product { Id = 9, Name = "Yamaha Pacifica 112V", Price = 199.99m, ImgUri = "yamaha_pacifica.jpg", Description = "Elektrická kytara s vynikajícím poměrem cena/výkon." },
                new Product { Id = 10, Name = "Fender Telecaster", Price = 799.99m, ImgUri = "fender_telecaster.jpg", Description = "Klasická kytara s jedinečným zvukem." },
                new Product { Id = 11, Name = "BOSS DS-1", Price = 49.99m, ImgUri = "boss_ds1.jpg", Description = "Kytarový pedál pro zkreslení." },
                new Product { Id = 12, Name = "MXR Phase 90", Price = 129.99m, ImgUri = "mxr_phase90.jpg", Description = "Fáze efekt pro kytaru." },
                new Product { Id = 13, Name = "Peavey 6505+", Price = 799.99m, ImgUri = "peavey_6505plus.jpg", Description = "Zesilovač pro metal a tvrdý rock." },
                new Product { Id = 14, Name = "Fender Mustang IV", Price = 649.99m, ImgUri = "fender_mustang.jpg", Description = "Kombo zesilovač s digitálními efekty." },
                new Product { Id = 15, Name = "Hofner Violin Bass", Price = 599.99m, ImgUri = "hofner_violin_bass.jpg", Description = "Ikonický basový nástroj s výrazným zvukem." },
                new Product { Id = 16, Name = "TC Electronic Ditto Looper", Price = 129.99m, ImgUri = "tc_electronic_ditto.jpg", Description = "Jednoduchý looper pro kytaristy." },
                new Product { Id = 17, Name = "Mesa Boogie Dual Rectifier", Price = 2399.99m, ImgUri = "mesa_boogie_rectifier.jpg", Description = "Vysokovýkonný zesilovač pro rock a metal." },
                new Product { Id = 18, Name = "Rickenbacker 4003", Price = 1499.99m, ImgUri = "rickenbacker_4003.jpg", Description = "Legendární basová kytara." },
                new Product { Id = 19, Name = "Ibanez Tube Screamer", Price = 169.99m, ImgUri = "ibanez_tube_screamer.jpg", Description = "Pedál zkreslení pro kytaru." },
                new Product { Id = 20, Name = "Line 6 Spider V 120", Price = 349.99m, ImgUri = "line6_spider_v.jpg", Description = "Kombo zesilovač s širokou paletou zvuků." },
                new Product { Id = 21, Name = "LTD EC-1000", Price = 849.99m, ImgUri = "ltd_ec1000.jpg", Description = "Elektrická kytara s vynikajícím tónem a designem." },
                new Product { Id = 22, Name = "EVH 5150III", Price = 1699.99m, ImgUri = "evh_5150iii.jpg", Description = "Vysoce kvalitní zesilovač pro tvrdý rock a metal." },
                new Product { Id = 23, Name = "Epiphone Les Paul Standard PlusTop Pro", Price = 599.99m, ImgUri = "epiphone_les_paul.jpg", Description = "Kytara s vynikajícím zvukem a komfortním designem." },
                new Product { Id = 24, Name = "Alesis Strike Pro Kit", Price = 1999.99m, ImgUri = "alesis_strike_pro_kit.jpg", Description = "Elektronická bicí souprava pro profesionály." },
                new Product { Id = 25, Name = "Roland TD-27", Price = 1799.99m, ImgUri = "roland_td27.jpg", Description = "Elektronické bicí pro domácí studio." },
                new Product { Id = 26, Name = "Squier Affinity Stratocaster", Price = 199.99m, ImgUri = "squier_affinity_stratocaster.jpg", Description = "Levná, ale kvalitní kytara pro začátečníky." },
                new Product { Id = 27, Name = "Marshall JCM800", Price = 1299.99m, ImgUri = "marshall_jcm800.jpg", Description = "Legendární zesilovač pro rockové kytaristy." },
                new Product { Id = 28, Name = "Fender Jazz Bass", Price = 899.99m, ImgUri = "fender_jazz_bass.jpg", Description = "Basová kytara s brilantním zvukem." },
                new Product { Id = 29, Name = "Yamaha F310", Price = 149.99m, ImgUri = "yamaha_f310.jpg", Description = "Akustická kytara pro začátečníky." },
                new Product { Id = 30, Name = "Takamine GD30", Price = 399.99m, ImgUri = "takamine_gd30.jpg", Description = "Akustická kytara s vynikajícím zvukem." },
                new Product { Id = 31, Name = "PRS SE Custom 24", Price = 799.99m, ImgUri = "prs_se_custom_24.jpg", Description = "Kytara s kvalitním zpracováním a tónem." },
                new Product { Id = 32, Name = "Gibson SG Standard", Price = 999.99m, ImgUri = "gibson_sg_standard.jpg", Description = "Elektrická kytara s ostrým zvukem." },
                new Product { Id = 33, Name = "Fender Mustang V2", Price = 349.99m, ImgUri = "fender_mustang_v2.jpg", Description = "Zesilovač pro kytaristy se spoustou efektů." },
                new Product { Id = 34, Name = "Behringer X32", Price = 2599.99m, ImgUri = "behringer_x32.jpg", Description = "Digitální mixážní pult pro profesionální zvukaře." },
                new Product { Id = 35, Name = "Mackie CR4", Price = 149.99m, ImgUri = "mackie_cr4.jpg", Description = "Studio monitory pro domácí nahrávací studio." },
                new Product { Id = 36, Name = "Korg Minilogue", Price = 399.99m, ImgUri = "korg_minilogue.jpg", Description = "Analogový syntezátor s bohatým zvukem." },
                new Product { Id = 37, Name = "Akai MPC Live", Price = 999.99m, ImgUri = "akai_mpc_live.jpg", Description = "Hudební sampler pro profesionály." },
                new Product { Id = 38, Name = "Roland Fantom 6", Price = 1999.99m, ImgUri = "roland_fantom_6.jpg", Description = "Pokročilý syntezátor pro live performance." },
                new Product { Id = 39, Name = "Arturia MiniLab 3", Price = 119.99m, ImgUri = "arturia_minilab_3.jpg", Description = "Mini klávesy pro domácí producenty." },
                new Product { Id = 40, Name = "Novation Launchkey 61", Price = 249.99m, ImgUri = "novation_launchkey_61.jpg", Description = "MIDI keyboard pro tvorbu hudby." },
                new Product { Id = 41, Name = "Native Instruments Komplete Kontrol", Price = 499.99m, ImgUri = "native_instruments_komplete.jpg", Description = "Pokročilý MIDI kontroler." },
                new Product { Id = 42, Name = "Ableton Push 2", Price = 649.99m, ImgUri = "ableton_push_2.jpg", Description = "Pokročilý hudební kontroler pro Ableton Live." },
                new Product { Id = 43, Name = "Rode NT1-A", Price = 229.99m, ImgUri = "rode_nt1a.jpg", Description = "Kondenzátorový mikrofon pro nahrávání." },
                new Product { Id = 44, Name = "AKG C414", Price = 999.99m, ImgUri = "akg_c414.jpg", Description = "Profesionální studiový mikrofon." },
                new Product { Id = 45, Name = "Audio-Technica AT2020", Price = 99.99m, ImgUri = "audio_technica_at2020.jpg", Description = "Kondenzátorový mikrofon pro domácí nahrávky." },
                new Product { Id = 46, Name = "Shure SM7B", Price = 399.99m, ImgUri = "shure_sm7b.jpg", Description = "Profesionální mikrofon pro nahrávání." },
                new Product { Id = 47, Name = "Fender American Professional II", Price = 1399.99m, ImgUri = "fender_american_professional_ii.jpg", Description = "Elektrická kytara s vynikajícím tónem." },
                new Product { Id = 48, Name = "Epiphone Les Paul Standard", Price = 799.99m, ImgUri = "epiphone_les_paul_standard.jpg", Description = "Kytara s vynikajícím zvukem." },
                new Product { Id = 49, Name = "Ibanez AZ2402", Price = 1699.99m, ImgUri = "ibanez_az2402.jpg", Description = "Kytara s kvalitním zpracováním a zvukem." },
                new Product { Id = 50, Name = "Yamaha Revstar 820", Price = 799.99m, ImgUri = "yamaha_revstar_820.jpg", Description = "Stylová kytara s vynikajícím zvukem." }            
            ];
        }
    }
}
