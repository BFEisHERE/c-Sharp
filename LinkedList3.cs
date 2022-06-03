using System;
// Ekleme - Silme İşlemleri
namespace LinkedList3
{
    class Program
    {
        class Node{
            //Düğüm ve göstericisi oluşturuldu
            public int data;
            public Node next;

            public Node(int data)
            {
                //Oluşturulan düğümü tanımladık
                this.data = data;
                next = null;
            }
        }
        class Liste
        {
            // Liste oluşturuldu
            // Listenin ilk düğümünü oluşturduk
            public Node head;

             public Liste(){
                 
                head = null;
             }

            public void sonaEkle(int data)
            {
                Node eleman = new Node(data);
                // İlk Düğüm Boş ise Eklenir
                if (head == null)
                {
                    head = eleman;
                    Console.WriteLine("Liste Oluşturuldu İlk Düğüm Girildi");
                }//Değilse Sonraki Düğüme Eklenir
                 // Son düğümün göstericisi her zaman null'dır
                else
                {
                    Node temp = head; // 1. düğümü tutan geçici düğüm oluşturduk
                    while (temp.next != null)
                    {
                        // gösterici null görene kadar devam et demektir
                        temp = temp.next;
                    }
                    temp.next = eleman;
                    Console.WriteLine("Sona Eleman Eklendi!");
                }
            }

            public void basaEkle(int data)
            {
                Node eleman = new Node(data);
                if (head == null)
                {
                    head = eleman;
                    Console.WriteLine("Liste Oluşturuldu. İlk Eleman Eklendi");
                }
                else
                {
                    // Listenin başına Eleman Eklendi
                    eleman.next = head; // Başlandı
                    head = eleman; // Head güncellendi
                }
            }
            
            public void Yazdır()
            {
                Node temp = head;

                if (head == null)
                {
                    Console.WriteLine("Liste Boştur");
                }
                else
                {
                    Console.Write("başı -->");
                    while (temp.next != null)
                    {
                        Console.Write(temp.data +" --> ");
                        temp = temp.next;
                    }
                    Console.Write(temp.data+" sonu");
                }
            }

            //Silme İşlemleri

            public void bastanSil()
            {
                if (head == null)
                {
                    Console.WriteLine("Liste Boştur");
                }
                else
                {
                    head = head.next; //Baştaki Düğüm Sil Demektir
                    Console.WriteLine("\nBaştaki Düğüm Silindi");
                }
            }

            public void sondanSil()
            {
                Node temp = head;
                Node temp2 = temp;
                if (head == null)
                {
                    Console.WriteLine("Liste Boştur");
                }
                else if (head.next == null)
                {
                    head = null;
                    Console.WriteLine("Listede Kalan Son Düğüm Silindi");
                }
                else
                {
                    while (temp.next != null)
                    {
                        temp2 = temp;
                        temp = temp.next;
                    }
                    temp2.next = null;
                    Console.WriteLine("Sondaki Düğüm Silindi");
                }
            }

            // ARAYA EKLEME - SİLME

            public void arayaEkle(int indis,int data)
            {
                Node eleman = new Node(data);
                bool sonuc = false;
                
                
                if (head == null && indis == 0) { 
                    head = eleman;
                    Console.WriteLine("Ekleme Yapıldı");
                    sonuc = true;
                }
                else if (indis == 0)
                {
                    basaEkle(data);
                    sonuc = true;
                }
                else
                {
                    int i = 0;
                    Node temp = head;
                    Node temp2 = head;
                    while (temp.next!= null)
                    {
                        if (i == indis)
                        {
                            sonuc = true;
                            temp2.next = eleman;
                            eleman.next = temp;
                            Console.WriteLine("Araya Eklendl");
                            i++;
                            break;
                        }
                        i++;
                        temp2 = temp;
                        temp = temp.next;
                    }
                    if (i == indis) // GErekli Değil Ama Kullanıcı Bir tane daha ekleme isterse eğer ki 
                    {
                        sonuc = true;
                        temp2.next = eleman;
                        eleman.next = temp;
                        Console.WriteLine("Araya Eklendi");
                    }
                }
                if (sonuc == false)
                    Console.WriteLine("Hatalı indis girişi yaptınız");
            }

            public void aradansil(int indis)
            {
                bool sonuc = false;

                if(head == null)
                {
                    Console.WriteLine("Liste Boş");
                    sonuc = true;
                }
                   
                else if (head.next == null && indis == 0)
                {
                    sonuc = true;
                    head = null;
                    Console.WriteLine("Listede Kalan Son elemanı Sildiniz");
                }
                else if (head.next != null && indis == 0)
                {
                    sonuc = true;
                    bastanSil();
                    Console.WriteLine("Eleman Silindi");
                }
                else
                {
                    int i = 0;

                    Node temp = head;
                    Node temp2 = head;

                    while (temp.next != null)
                    {
                        if(i == indis)
                        {
                            sonuc = true;
                            temp2.next = temp.next;
                            Console.WriteLine("Aradan Eleman Sildiniz");
                            i++;
                            break;
                        }
                        temp2 = temp;
                        temp = temp.next;
                        i++;
                    }
                    if (i == indis)
                    {
                        sonuc = true;
                        temp2.next =null;
                        Console.WriteLine("Aradan Eleman Sildiniz");
                        i++;
                    }

                    if (sonuc == false)
                        Console.WriteLine("Hatalı indis girişi yapıldı");
                }
            }

            public void elemanSay()
            {
                int sayac=0;
                if(head ==null)
                    Console.WriteLine("Eleman sayısı: "+sayac);
                else
                {
                    Node temp = head;

                    while (temp.next != null)
                    {
                        sayac ++;
                        temp = temp.next;
                    }
                    sayac++;
                    Console.WriteLine("Eleman Sayısı : "+sayac);
                }
            }
        }



        static void Main(string[] args){
            /*
            Liste tylist = new Liste();

            tylist.sonaEkle(10);
            tylist.sonaEkle(20);
            tylist.sonaEkle(30);

            tylist.Yazdır();
            Console.WriteLine();

            tylist.basaEkle(5);
            tylist.sonaEkle(100);

            tylist.Yazdır();

            tylist.bastanSil();
            tylist.sondanSil();
            tylist.sondanSil();
            tylist.sondanSil();
            tylist.sondanSil();
            tylist.Yazdır();
            */
            int sayı,indis;
            Liste tlist = new Liste();

            int secim = menu();

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1: Console.Write("Sayı: "); sayı = int.Parse(Console.ReadLine());
                        tlist.basaEkle(sayı);
                        break;
                    case 2: Console.Write("Sayı : "); sayı = int.Parse(Console.ReadLine());
                        tlist.sonaEkle(sayı);
                        break;
                    case 3:
                        Console.Write("indis : "); indis = int.Parse(Console.ReadLine());
                        Console.Write("Sayı : "); sayı = int.Parse(Console.ReadLine());
                        tlist.arayaEkle(indis,sayı);
                        break;
                    case 4:
                        tlist.bastanSil();
                        break;
                    case 5:
                        tlist.sondanSil();
                        break; 
                    case 6:
                        Console.Write("indis : "); indis = int.Parse(Console.ReadLine());
                        tlist.aradansil(indis);
                        break; 
                    case 7:
                        tlist.elemanSay();
                        break;
                    case 0:
                        Console.WriteLine("Program Sonlandırıldı!");
                        break;
                    default:
                        Console.WriteLine("Hatalı Seçim Yaptınız");
                        break;
                }
                //Console.Clear();
                tlist.Yazdır();
                secim = menu();
            }

            Console.ReadKey();
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("\n1. Basa Ekle");
            Console.WriteLine("2. Sona Ekle");
            Console.WriteLine("3. Araya Ekle");
            Console.WriteLine("4. Baştan Sil");
            Console.WriteLine("5. Sondan Sil");
            Console.WriteLine("6. Aradan Sil");
            Console.WriteLine("7. Eleman Sayısı");
            Console.WriteLine("0. Programı Kapat");
            Console.Write("Seçiniz : ");
            secim =int.Parse(Console.ReadLine());
            return secim;
        }
    }
}
