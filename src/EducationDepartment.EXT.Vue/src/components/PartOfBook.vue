<template>
  <div class="partOfBook">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj część książki</h3>

    <form style ="margin-top:20px" v-on:submit="addPartOfBook">
      <div class="form-group">
        <label for="autorImput">Autor</label>
        <input type="text" class="form-control"   placeholder="autor" v-model="partOfBook.autor">
          </br>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control"   placeholder="tytuł" v-model="partOfBook.title">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control" v-model="partOfBook.description" rows="5"></textarea>
            </br>

            <label for="example-date-input"  >Data</label>
            </br>

            <input class="form-control" type="date" value="2018-12-19" v-model="partOfBook.date">
              </br>

            <label for="pagesImput">Strony</label>
            <input type="text" class="form-control"  v-model="partOfBook.pages" placeholder="strony">
              </br>

            


              <label for="cityImput">Miasto</label>
              <input type="text" class="form-control"   placeholder="miasto" v-model="partOfBook.city">
                </br>

                <label for="publisherImput">Wydawca</label>
                <input type="text" class="form-control"   placeholder="wydawca" v-model="partOfBook.publisher" >
                  </br>






                  <label>Okładka</label>
                  <div class="input-group">
                    <span class="input-group-btn">
                      <span class="btn btn-default btn-file">
                        Wybierz… <input type="file" id="imgInp">
                </span>
                    </span>
                    <input type="text" class="form-control" readonly="">
        </div>
                  <img id='img-upload'/>




                  <label for="exampleInputFile">Załączniki</label>
                  <input type="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp">
                    <small id="fileHelp" class="form-text text-muted">This is some placeholder block-level help text for the above input. It's a bit lighter and easily wraps to a new line.</small>


                    <button   class="btn btn-lg btn-primary btn-block">Dodaj część książki</button>


                  </div>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'PartOfBook',
  data(){
  return {
  partOfBook: {},
  alert: ""
  }
  },
  methods: {
  addPartOfBook(e) {
  if (
  !this.partOfBook.autor ||
  !this.partOfBook.title
  ) {
  this.alert = "Autor i tytuł to pola wymagane";
  } else {
  let newPartOfBook = {
  Autor: this.partOfBook.autor,
  Title: this.partOfBook.title,
  Description: this.partOfBook.description,
  Date: this.partOfBook.date,
  City: this.partOfBook.city,
  Pages: this.partOfBook.pages,
  Publisher: this.partOfBook.publisher




  }
  this.$http.post('http://localhost:50906/api/accounts', newPartOfBook)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano część książki'}});
  });

  e.preventDefault();
  }
  e.preventDefault();
  }
  },
  components: {
  Alert
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
