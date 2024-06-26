# .NET & Elasticsearch ile Veri Hızlandırma Projesi

Bu proje, .NET ve Elasticsearch kullanarak veri hızlandırma işlemlerini gerçekleştirmeyi amaçlamaktadır. Proje ayrıca Docker, Kibana ve Postman kullanarak geliştirme ve test süreçlerini kolaylaştırmayı hedeflemektedir.

## Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Docker](https://www.docker.com/products/docker-desktop)
- [Postman](https://www.postman.com/downloads/)
- [Git](https://git-scm.com/)

## Kurulum

### 1. Depoyu Klonlama

Öncelikle bu projeyi yerel makinenize klonlayın:

```bash
git clone https://github.com/kullanici/proje-adi.git
cd proje-adi
```

### 2. Docker Servislerini Başlatma

Docker Compose dosyasını kullanarak Elasticsearch ve Kibana servislerini başlatın:

```bash
docker-compose up -d
```

Bu komut `elasticsearch` ve `kibana` servislerini arka planda başlatacaktır.

### 3. Elasticsearch YML Konfigürasyon Ayarları

Elasticsearch servisi için gerekli olan temel konfigürasyon ayarları `docker-compose.yml` dosyasında belirtilmiştir:

```yaml
version: '3.8'

services:
  elasticsearch:
    image: docker.elastic.co/elasticsearch/elasticsearch:8.7.1
    environment:
      - xpack.security.enabled=false
      - "discovery.type=single-node"
    ports: 
      - 9200:9200
    volumes:
     - elasticsearch-data:/usr/share/elasticsearch/data

  kibana:
    image: docker.elastic.co/kibana/kibana:8.7.1
    ports:
      - 5601:5601
    environment:
      ELASTICSEARCH_HOSTS: http://elasticsearch:9200

volumes:
 elasticsearch-data:
    driver: local
```

### 4. .NET Projesini Çalıştırma

.NET projesini çalıştırmak için aşağıdaki komutları kullanın:

```bash
dotnet restore
dotnet build
dotnet run
```

### 5. Postman ile API Testleri

Projenin API uç noktalarını test etmek için Postman'i kullanabilirsiniz. Postman koleksiyon dosyasını içe aktarın ve API uç noktalarını test edin. API uç noktaları genellikle aşağıdaki formatta olacaktır:

```
http://localhost:5000/api/{endpoint}
```

## Kullanım

Proje çalıştırıldıktan sonra aşağıdaki servisler aktif olacaktır:

- **Elasticsearch**: [http://localhost:9200](http://localhost:9200)
- **Kibana**: [http://localhost:5601](http://localhost:5601)
- **.NET API**: [http://localhost:5000](http://localhost:5000)

![50bin kayıt](https://github.com/paradoxxo1/ElasticSearchDataAnalysisExample/assets/124463263/1c3fca60-8b16-4009-adc3-0f2bd24b3ba7)
![kibana](https://github.com/paradoxxo1/ElasticSearchDataAnalysisExample/assets/124463263/29056bca-8847-45c1-8bc9-fee6e023bd5f)
![docker yml](https://github.com/paradoxxo1/ElasticSearchDataAnalysisExample/assets/124463263/df4320d6-dc4a-4a7f-8a68-6d196668e1b5)
![elastic search öncesi](https://github.com/paradoxxo1/ElasticSearchDataAnalysisExample/assets/124463263/88e9ce52-c351-4cbc-b9a0-a3ba971d9c96)
![elastic search sonrası](https://github.com/paradoxxo1/ElasticSearchDataAnalysisExample/assets/124463263/6be01e4c-25b8-4dd2-8300-0d63a8bf6f25)



Elasticsearch ve Kibana arayüzlerine erişerek verilerinizi görüntüleyebilir ve analiz edebilirsiniz. Postman ile API uç noktalarını test ederek veri işlemlerini gerçekleştirebilirsiniz.

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir çekme isteği (pull request) gönderin. Her türlü geri bildirim ve katkı için teşekkür ederiz.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.
