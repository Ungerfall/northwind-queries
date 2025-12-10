import { createAsyncThunk, createSlice, PayloadAction } from '@reduxjs/toolkit';
import { RootState, AppThunk } from '../../app/store';

export interface LearningTaskSolution {
    id: string;
    query: string;
    rowCount: number;
};

export interface LearningTask {
    id: string;
    projectColumns: string | null;
    description: string;
    solution: LearningTaskSolution | null;
};

export interface LearningModule {
    id: string;
    name: string;
    tasks: Array<LearningTask>;
};

export interface LearningModuleState {
    modules: Array<LearningModule>;
    status: 'loading' | 'failed' | 'idle';
}

const initialState: LearningModuleState = {
    modules: new Array<LearningModule>(),
    status: 'idle'
};

export const learningModuleSlice = createSlice({
    name: 'learningModule',
    initialState,
    reducers: {


    }

})

