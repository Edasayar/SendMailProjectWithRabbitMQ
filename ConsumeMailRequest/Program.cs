using Core;
using System;

namespace ConsumeMailRequest
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("RabbitMQ işlemleri başlatılıyor...");

            var cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = cancellationTokenSource.Token;

            var emailConsumerService = new EmailConsumerService(); // EmailConsumerService sınıfını kullanmış gibi düşünelim

            // Görevi başlat
            var task = emailConsumerService.ExecuteAsync(cancellationToken);

            Console.WriteLine("RabbitMQ işlemleri başlatıldı. Çıkmak için 'q' tuşuna basın...");

            // 'q' tuşuna basılıncaya kadar devam et
            while (true)
            {
                var key = Console.ReadKey(intercept: true);
                if (key.KeyChar == 'q')
                {
                    cancellationTokenSource.Cancel(); // İşlemi iptal et
                    break;
                }
            }

            // İptal edilmiş görevin tamamlanmasını bekleyin
            await task;
            Console.WriteLine("Program sonlandırıldı.");
        }
    }
}
