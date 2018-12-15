<template>
  <div class="article">
    <h3>Dodaj artykuł</h3>

    <form style ="margin-top:20px">
      <div class="form-group">
        <label for="autorImput">Autor</label>
        <input type="text" class="form-control" id="autorImput" placeholder="autor">
          </br>

          <label for="titleImput">Tytuł</label>
          <input type="text" class="form-control" id="titleImput" placeholder="tytuł">
            </br>

            <label for="descriptionBook">Opis</label>
            </br>
            <textarea class="form-control" id="descriptionBook" rows="5"></textarea>
            </br>

            <label for="magazinNameImput">Magazyn/czasopismo</label>
            <input type="text" class="form-control" id="magazinNameImput" placeholder="nazwa czasopisma/magazynu">
              </br>

            <label for="example-date-input"  >Data</label>
            </br>

              <input class="form-control" type="date" value="2018-11-19" id="example-date-input">
                </br>

            <label for="pagesImput">Strony</label>
            <input type="text" class="form-control" id="pagesImput" placeholder="strony">
              </br>

             


                <label for="cityImput">Miasto</label>
                <input type="text" class="form-control" id="cityImput" placeholder="miasto">
                  </br>

                  <label for="publisherImput">Wydawca</label>
                  <input type="text" class="form-control" id="publisherImput" placeholder="wydawca">
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


                      <button   class="btn btn-lg btn-primary btn-block">Dodaj artykuł</button>


                    </div>

    </form>

  </div>
</template>

<script>
  export default {
  name: 'Article',
  data(){
  return{}
  }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped="">
</style>
