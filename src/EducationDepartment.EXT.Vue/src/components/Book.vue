<template>
  <div class="book">
    <Alert v-if="alert" v-bind:message="alert" />
    <h3>Dodaj książkę</h3>

    <form style ="margin-top:20px"  v-on:submit="addBook">
      <div class="form-group">
        <label for="autorImput">Autor</label>
        <input type="text" class="form-control"   placeholder="autor" v-model="book.autor">
          </br>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control"   placeholder="tytuł" v-model="book.title">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control"  v-model="book.description" rows="5"></textarea>
            </br>

            <label for="example-date-input"  >Data</label>
            </br>

            <input class="form-control" type="date" value="2018-12-19"  v-model="book.date">
              </br>


              <label for="cityImput">Miasto</label>
              <input type="text" class="form-control"  v-model="book.city" placeholder="miasto">
                </br>

                <label for="publisherImput">Wydawca</label>
                <input type="text" class="form-control"   placeholder="wydawca" v-model="book.publisher">
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


                    <button   class="btn btn-lg btn-primary btn-block">Dodaj książkę</button>


                  </div>

    </form>

  </div>
</template>

<script>
  import Alert from "./Alert"
  export default {
  name: 'Book',
  data(){
  return {
  book: {},
  alert: ""
  }
  },
  methods: {
  addBook(e) {
  if (
  !this.book.autor ||
  !this.book.title 
  ) {
  this.alert = "Autor i tytuł to pola wymagane";
  } else {
  let newBook = {
  Autor: this.book.autor,
  Title: this.book.title,
  Description: this.book.description,
  Publisher: this.book.publisher,
  Date: this.book.date,
  City: this.book.city
 



  }
  this.$http.post('http://localhost:50906/api/accounts', newBook)
  .then(function(response){
  this.$router.push({path: '/', query: {alert: 'Dodano książkę'}});
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
