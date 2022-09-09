import React from 'react';

import { 
  TextField,
  Button,
  FormControl
} from '@mui/material';

function NovelList () {
  const [novels, setNovels] = React.useState([]);
  const [newNovel, setNewNovel] = React.useState({});

  function onNewNovelFieldBlur(e, item) {
    let updatedNewNovel = {...newNovel};
    updatedNewNovel[item] = e.target.value;
    setNewNovel(updatedNewNovel);
  }

  async function addNovel() {
    if (!newNovel.title || !newNovel.descrip) {
      console.log('hassdg');
      return; 
    }

    const url = 'https://localhost:7000/api/NovelPlans';
    const init = {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({ newNovel })
    };

    // get the return response
    const response = await fetch(url, init);
    const data = await response.json();

    let newNovels = [...novels]; 
    newNovels.push(newNovel);
    setNovels(newNovels);
  }

  return (
    <>

      { /* Display all novels */
        novels.map((q, i) => {
          return (
          <div>
            A novel will be displayed here
          </div>);
        })
      }


      {/* Form to submit new novels */}
      <FormControl>
        <TextField 
          id="novel-title" 
          label="Novel Title" 
          variant="outlined" 
          onBlur={(e) => {onNewNovelFieldBlur(e, 'title')}}
        />
        <TextField 
          id="novel-descrip" 
          label="Novel Description" 
          variant="outlined" 
          onBlur={(e) => {onNewNovelFieldBlur(e, 'descrip')}}
        />
        <Button
          color='primary'
          variant='outlined'
          onClick={addNovel}
        >
          Add Novel
        </Button>
      </FormControl>
    </>
  );
}

export default NovelList;