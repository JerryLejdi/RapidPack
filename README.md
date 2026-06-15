# 📦 RapidPack – System Wyceny Przesyłek

Witajcie w zespole deweloperskim! 👋
Waszym zadaniem jest stworzenie aplikacji desktopowej dla lokalnej firmy kurierskiej **RapidPack**. Klient ma dość liczenia cen na kartce i potrzebuje niezawodnego narzędzia dla swoich pracowników.

## 📩 Zadanie: E-mail od Klienta

Poniżej znajduje się specyfikacja wymagań otrzymana bezpośrednio od właściciela firmy. Waszym pierwszym zadaniem jest **analiza tego tekstu** i zamiana go na działający kod.

> **Temat:** Aplikacja do wyceny paczek – PILNE
> **Od:** Jan Kowalski (CEO RapidPack)
>
> "Cześć! Potrzebuję prostego programu dla moich pracowników na recepcji.
>
> Musimy szybko wyceniać paczki. Klient podaje **wymiary** (wysokość, szerokość, głębokość w cm) i **wagę**.
> Ale uwaga:
> 1. Nie wozimy paczek cięższych niż **30 kg** – program ma krzyczeć błędem, jak ktoś tyle wpisze!
> 2. Cena bazowa to **10 zł**. Każdy kilogram to dodatkowe **2 zł**.
> 3. Jeśli paczka jest duża (suma wymiarów > 150 cm), to doliczamy opłatę gabarytową (**+50%** do ceny końcowej).
>
> Mamy też usługi dodatkowe:
> - **Ekspres** (Checkbox): kosztuje **+15 zł**.
> - **Typ przesyłki** (wybór z listy): Standardowa, Ostrożnie (szkło), Paleta.
>   - Jak "Ostrożnie", to dolicz **10 zł**.
>   - Jak "Paleta", to cena jest stała **100 zł** (waga i wymiary nie mają znaczenia, chyba że przekroczy 30 kg, to błąd).
>
> Na dole ma być duży przycisk "Wyceń". Po kliknięciu ma się pojawić podsumowanie z ceną i danymi, żeby pracownik mógł to przepisać na list przewozowy.
> Aha, i zróbcie to ładnie, żeby pola były równo."

---

## 🛠️ Podział Pracy (Pair Programming)

Projekt realizujecie w parach. Podzielcie się rolami, aby pracować równolegle:

### 👤 Developer A (Frontend & UI)
Twoim zadaniem jest stworzenie interfejsu w **Avalonia UI**.
* Zaprojektuj formularz używając `Grid`, `StackPanel` i `WrapPanel`.
* Użyj odpowiednich kontrolek: `TextBox` (dane), `CheckBox` (ekspres), `ComboBox` (typ), `Button` (akcja).
* Zadbaj o estetykę i czytelność (marginesy, wyrównanie).
* **Ważne:** Nadaj kontrolkom nazwy (`x:Name`), np. `WeightTextBox`, aby Developer B mógł się do nich odwołać.

### 👤 Developer B (Backend & Logic)
Twoim zadaniem jest napisanie "mózgu" aplikacji w czystym C# oraz testów.
* Stwórz klasę `ParcelCalculator`.
* Napisz metody obliczające cenę (np. `CalculatePrice(...)`) oraz walidujące dane.
* Napisz **Testy Jednostkowe (xUnit)**, które sprawdzą, czy logika działa poprawnie (np. czy paczka > 30kg rzuca błąd).
* Nie dotykasz plików `.axaml`!

### 🤝 Integracja (Wspólnie)
Na koniec musicie połączyć siły w pliku `MainWindow.axaml.cs`.
* Pobrać dane z formularza (Frontend).
* Przekonwertować teksty na liczby (`int.TryParse`).
* Przekazać dane do `ParcelCalculator` (Backend).
* Wyświetlić wynik lub błąd w oknie aplikacji.

---

## ✅ Wymagania Techniczne

1.  **Technologia:** .NET / Avalonia UI / xUnit.
2.  **Dozwolone kontrolki:** `StackPanel`, `Grid`, `WrapPanel`, `TextBlock`, `TextBox`, `Button`, `CheckBox`, `RadioButton`, `ComboBox`.
3.  **Architektura:** Logika biznesowa MUSI być oddzielona od UI (osobna klasa).
4.  **Repozytorium:**
    * Regularne commity (min. 5 na osobę).
    * Podpięty Webhook do Discorda (kanał `#github-feed`).
    * Wypełniona tablica KANBAN (min. 3 zadania na osobę)

---

## 🧪 Scenariusze Testowe (xUnit)

Wasze testy muszą pokryć co najmniej te przypadki:
- [ ] **Waga:** Czy 35 kg powoduje błąd?
- [ ] **Gabaryt:** Czy paczka 50x50x60 cm ma doliczone +50% ceny?
- [ ] **Paleta:** Czy wybranie "Palety" ustawia cenę na sztywno (100 zł), ignorując wagę?
- [ ] **Ekspres:** Czy zaznaczenie opcji dodaje 15 zł?

---

## 🚀 Jak zacząć?

1.  Sklonujcie to repozytorium na dysk przez użycie **USE TEMPLATE** (`git clone ...`)
2.  Dodajcie Webhooka w ustawieniach repozytorium (link na Discordzie).
3.  Ustalcie podział ról na Discordzie.
4.  Powodzenia! Niech kod będzie z Wami! 💻

---
# KANBAN
## Konfiguracja
Zanim napiszą pierwszą linijkę kodu, muszą:
- Wejść w zakładkę `Projects` w swoim repozytorium na GitHubie i utworzyć nową tablicę (szablon "Board" - Todo, In Progress, Done).
- Przeczytać e-mail od klienta (z pliku `README`).
- Rozbić ten e-mail na małe zadania, tworząc `Issues `(Problemy/Zadania).
- Dodać te `Issues` do tablicy Kanban i przypisać do konkretnej osoby (Assignees) – Dev A lub Dev B.

## Przykładowe zadania
Przykładowe zadania (Issues), które powinni sami wywnioskować z maila:
- [UI] Stworzenie szkieletu okna (Grid, StackPanel) i podział na sekcje.
- [UI] Dodanie kontrolek wejściowych: waga (TextBox) i wymiary (TextBox).
- [Logika] Stworzenie klasy ParcelCalculator z metodą obliczającą cenę bazową i dopłatę za kilogramy.
-[Logika] Napisanie testu xUnit dla paczki ważącej powyżej 30 kg (oczekiwany błąd).
-[Logika] Implementacja opłaty gabarytowej (+50% jeśli suma wymiarów > 150 cm) + testy.
- [Integracja] Podpięcie zdarzenia kliknięcia przycisku "Wyceń" do logiki kalkulatora.

  
